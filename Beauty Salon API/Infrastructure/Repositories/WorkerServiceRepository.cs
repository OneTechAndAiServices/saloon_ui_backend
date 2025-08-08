using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class WorkerServiceRepository : GenericRepository<WorkerService>, IWorkerServiceRepository
    {
        public WorkerServiceRepository(ApplicationDbContext context) : base(context) { }
        // Add custom methods for WorkerService if needed
    }
} 