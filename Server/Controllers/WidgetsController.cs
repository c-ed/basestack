using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqwareBase.Domain.Model;
using SqwareBase.Domain.Services;

namespace SqwareBase.Server.Controllers
{
    public class WidgetsController : DomainController
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
