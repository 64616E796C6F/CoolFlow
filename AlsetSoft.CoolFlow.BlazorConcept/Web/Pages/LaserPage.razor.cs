using AlsetSoft.CoolFlow.BlazorConcept.Services;
using AlsetSoft.CoolFlow.BlazorConcept.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace AlsetSoft.CoolFlow.BlazorConcept.Web.Pages
{

    public partial class LaserPage
    {
        [Inject] IJSRuntime JSRuntime { get; set; }

        [Inject] LaserService LaserService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public double Fullness { get; set; }
        public double UnFullness { get; set; }

        protected override void OnInitialized()
        {
            if (int.TryParse(Id, out int id))
            {
                var data = LaserService.GetMultiplexorData(id);
                if (data != null)
                {
                    List<double> averageValues = new();

                    foreach (var item in data.Data)
                    {
                        double averageValue = item.Values.Average();
                        averageValues.Add(averageValue);
                    }

                    double overallAverage = averageValues.Any() ? averageValues.Average() : 0;

                    Fullness = (Helper.MaxDistance - overallAverage) / Helper.MaxDistance * 100; // заповненість 99.33
                    UnFullness = 100 - Fullness;
                }
                else
                {
                    // редірект на головну пейджу з лазерами
                }
            }
            else
            {
                // редірект на головну пейджу з лазерами
            }
        }
    }
}
