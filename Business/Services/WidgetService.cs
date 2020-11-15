using System.Collections.Generic;
using System.Linq;
using SqwareBase.Business.Data;
using SqwareBase.Business.Model;

namespace SqwareBase.Business.Services
{
    public class WidgetService
    {
        private readonly BusinessDbContext _dbContext;

        public WidgetService(BusinessDbContext dbContext)
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
