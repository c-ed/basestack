using System;
namespace SqwareBase.Business.Data
{
    public static class BusinessDbInitializer
    {
        public static void Initialize(BusinessDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.SaveChanges();
        }
    }
}
