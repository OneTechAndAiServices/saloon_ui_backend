using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AddOnRepository : GenericRepository<AddOn>, IAddOnRepository
    {
        public AddOnRepository(ApplicationDbContext context) : base(context) { }
        // Add custom methods for AddOn if needed
    }
} 