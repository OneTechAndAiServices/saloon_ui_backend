using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ServiceAddOnRepository : GenericRepository<ServiceAddOn>, IServiceAddOnRepository
    {
        public ServiceAddOnRepository(ApplicationDbContext context) : base(context) { }
        // Add custom methods for ServiceAddOn if needed
    }
} 