using AlsetSoft.CoolFlow.BlazorConcept.Services;
using AlsetSoft.CoolFlow.BlazorConcept.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;


namespace AlsetSoft.CoolFlow.BlazorConcept.Web.Components
{

    public partial class ChartSecondComponent
    {
        [Parameter]
        public double Fullness { get; set; }

        [Parameter]
        public double UnFullness { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Description { get; set; }

        public List<ChartData> ChartData => new() { new() { Value = UnFullness, Color = "#B7B7B7" }, new() { Value = Fullness, Color = "#4657EF" } };
    }
}
