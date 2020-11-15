using System;

namespace SqwareBase.Domain.Model
{
    public class Widget
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class WidgetResource
    {
        public string Name { get; set; }
    }
}
