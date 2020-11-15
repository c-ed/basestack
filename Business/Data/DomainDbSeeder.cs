using System.Collections.Generic;
using SqwareBase.Business.Model;

namespace SqwareBase.Business.Data
{
    public class BusinessDbSeeder
    {
        private readonly BusinessDbContext _dbContext;

        public BusinessDbSeeder(BusinessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            _dbContext.Widgets.AddRange(new List<Widget>
            {
                new Widget { Name = "Widget One" },
                new Widget { Name = "Widget Two" },
                new Widget { Name = "Widget Three" }
            });

            _dbContext.SaveChanges();
        }
    }
}
