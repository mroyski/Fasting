using Fasting.Data;
using Fasting.Models;
using Fasting.Models.Chart;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Fasting.ViewComponents
{
    [ViewComponent(Name = "chartjs")]
    public class ChartJsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly int completed;
        private readonly int notCompleted;

        public ChartJsViewComponent(ApplicationDbContext context)
        {
            _context = context;
            var completionList = _context.Rhythm.ToList();
            completed = completionList.Where(x => x.Achieved == true).Count();
            notCompleted = completionList.Where(x => x.Achieved == false).Count();
        }

        public IViewComponentResult Invoke()
        {
            // Ref: https://www.chartjs.org/docs/latest/
            var chartData = @"
            {
                type: 'bar',
                responsive: true,
                data:
                {
                    labels: ['Not Completed', 'Completed'],
                    datasets: [{
                        label: 'Achievement',
                        data: [" + $"{notCompleted}, {completed}" + @"],
                        backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                            ],
                        borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                            ],
                        borderWidth: 1
                    }]
                },
                options:
                {
                    scales:
                    {
                        yAxes: [{
                            ticks:
                            {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            }";

            var chart = JsonConvert.DeserializeObject<ChartJs>(chartData);
            var chartModel = new ChartJsViewModel
            {
                Chart = chart,
                ChartJson = JsonConvert.SerializeObject(chart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                })
            };

            return View(chartModel);
        }
    }
}
