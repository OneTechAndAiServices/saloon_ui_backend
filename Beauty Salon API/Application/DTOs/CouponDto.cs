using System;

namespace Application.DTOs
{
    public class CouponDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public int? UsageLimit { get; set; }
        public int TimesUsed { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
} 