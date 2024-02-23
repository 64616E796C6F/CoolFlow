using AlsetSoft.CoolFlow.BlazorConcept.Models;
using AlsetSoft.CoolFlow.BlazorConcept.Services;
using AlsetSoft.CoolFlow.BlazorConcept.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AlsetSoft.CoolFlow.BlazorConcept.Web.Pages
{

    public partial class LaserPage
    {
        [Inject] IJSRuntime JSRuntime { get; set; }

        [Inject] LaserService LaserService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public DeviceMultiplexorData Data { get; set; }

        public double Fullness { get; set; }
        public double UnFullness { get; set; }

        public double Fullness1 { get; set; }
        public double UnFullness1 { get; set; }

        public double Fullness2 { get; set; }
        public double UnFullness2 { get; set; }

        protected override void OnInitialized()
        {
            if (int.TryParse(Id, out int id))
            {
                var data = LaserService.GetMultiplexorData(id);
                if (data != null)
                {
                    Data = data;
                    Data.PropertyChanged += Data_PropertyChanged;
                    test();
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

        private void test() 
        {
            List<double> averageValues = new();

            foreach (var item in Data.Data)
            {
                double averageValue = item.Values.Average();
                averageValues.Add(averageValue);
            }

            double overallAverage = averageValues.Any() ? averageValues.Average() : 0;

            Fullness = (Helper.MaxDistance - overallAverage) / Helper.MaxDistance * 100; // заповненість 99.33
            UnFullness = 100 - Fullness;

            Fullness1 = (Helper.MaxDistance - averageValues[0]) / Helper.MaxDistance * 100;
            UnFullness1 = 100 - Fullness1;

            Fullness2 = (Helper.MaxDistance - averageValues[1]) / Helper.MaxDistance * 100;
            UnFullness2 = 100 - Fullness2;
        }

        private async void Data_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            test();
            await InvokeAsync(StateHasChanged);
        }
    }
}
