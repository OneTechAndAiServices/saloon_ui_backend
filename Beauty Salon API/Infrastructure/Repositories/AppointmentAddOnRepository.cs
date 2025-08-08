using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AppointmentAddOnRepository : GenericRepository<AppointmentAddOn>, IAppointmentAddOnRepository
    {
        public AppointmentAddOnRepository(ApplicationDbContext context) : base(context) { }
        // Add custom methods for AppointmentAddOn if needed
    }
} 