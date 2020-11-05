using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SqwareBase.Business.Data;
using SqwareBase.Business.Model;

namespace SqwareBase.Business.Controllers
{
    public class WidgetsController : BaseBusinessController
    {
        private readonly BusinessDbContext _dbContext;

        public WidgetsController(BusinessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<WidgetResource> Get()
        {
            var resources = _dbContext.Widgets.Select(widget => new WidgetResource
            {
                Name = widget.Name
            }).ToList();

            return resources;
        }
    }
}
