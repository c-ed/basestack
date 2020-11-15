using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqwareBase.Business.Model;
using SqwareBase.Business.Services;

namespace SqwareBase.Server.Controllers
{
    public class WidgetsController : BusinessController
    {
        private readonly WidgetService _widgetsService;

        public WidgetsController(WidgetService widgetsService)
        {
            _widgetsService = widgetsService;
        }

        [HttpGet]
        public IEnumerable<WidgetResource> Get()
        {
            return _widgetsService.GetWidgets();
        }
    }
}
