using System;
using Fasting.Models.Chart;
using Fasting.ViewComponents;
using Newtonsoft.Json;

namespace Fasting.Models
{
    public class ChartJsViewModel
    {
        public ChartJs Chart { get; set; }
        public string ChartJson { get; set; }
    }
}
