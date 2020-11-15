using System.Collections.Generic;
using SqwareBase.Domain.Model;

namespace SqwareBase.Domain.Data
{
    public class DomainDbSeeder
    {
        private readonly DomainDbContext _dbContext;

        public DomainDbSeeder(DomainDbContext dbContext)
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
