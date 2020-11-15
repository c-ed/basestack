using SqwareBase.Domain.Data;

namespace SqwareBase.Domain.Services
{
    public class DomainService
    {
        private readonly DomainDbContext _dbContext;
        private readonly DomainDbSeeder _dbSeeder;

        public DomainService(DomainDbContext dbContext, DomainDbSeeder dbSeeder)
        {
            _dbContext = dbContext;
            _dbSeeder = dbSeeder;
        }

        public void Start()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _dbSeeder.Seed();
        }
    }
}
