using System.Collections.Generic;
using System.Linq;
using SqwareBase.Domain.Data;
using SqwareBase.Domain.Model;

namespace SqwareBase.Domain.Services
{
    public class WidgetService
    {
        private readonly DomainDbContext _dbContext;

        public WidgetService(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<WidgetResource> GetWidgets()
        {
            var resources = _dbContext.Widgets.Select(widget => new WidgetResource
            {
                Name = widget.Name
            }).ToList();

            return resources;
        }
    }
}
