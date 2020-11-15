using SqwareBase.Business.Data;

namespace SqwareBase.Business.Services
{
    public class BusinessService
    {
        private readonly BusinessDbContext _dbContext;
        private readonly BusinessDbSeeder _dbSeeder;

        public BusinessService(BusinessDbContext dbContext, BusinessDbSeeder dbSeeder)
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
