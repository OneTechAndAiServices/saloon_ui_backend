using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using Application.Interfaces;
using Application.DTOs;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System;

[ApiController]
[Route("api/[controller]")]
public class StripeController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IConfiguration _config;

    public StripeController(IPaymentService paymentService, IConfiguration config)
    {
        _paymentService = paymentService;
        _config = config;
    }

    [HttpPost("create-checkout-session")]
    public ActionResult CreateCheckoutSession([FromBody] CreateCheckoutSessionRequest request)
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(request.Amount * 100), // amount in cents
                        Currency = request.Currency,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = request.ProductName,
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = request.SuccessUrl,
            CancelUrl = request.CancelUrl,
            Metadata = new Dictionary<string, string>
            {
                { "BookingId", request.BookingId.ToString() }
            }
        };

        var service = new SessionService();
        Session session = service.Create(options);

        return Ok(new { sessionId = session.Id, url = session.Url });
    }

    [HttpPost("webhook")]
    public async Task<IActionResult> StripeWebhook()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        var stripeEvent = EventUtility.ConstructEvent(
            json,
            Request.Headers["Stripe-Signature"],
            _config["Stripe:WebhookSecret"]
        );

        // Correct usage: Events.CheckoutSessionCompleted
        if (stripeEvent.Type == "checkout.session.completed")
        {
            var session = stripeEvent.Data.Object as Stripe.Checkout.Session;
            var bookingId = session.Metadata.ContainsKey("BookingId") ? long.Parse(session.Metadata["BookingId"]) : 0;

            var paymentDto = new PaymentDto
            {
                BookingId = bookingId,
                Method = "Stripe",
                Amount = (decimal)(session.AmountTotal / 100.0),
                Currency = session.Currency,
                Status = "Completed",
                TransactionId = session.PaymentIntentId,
                PaidAt = DateTime.UtcNow
            };

            await _paymentService.AddAsync(paymentDto);
        }

        return Ok();
    }
}

public class CreateCheckoutSessionRequest
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "usd";
    public string ProductName { get; set; }
    public string SuccessUrl { get; set; }
    public string CancelUrl { get; set; }
    public long BookingId { get; set; }
} 