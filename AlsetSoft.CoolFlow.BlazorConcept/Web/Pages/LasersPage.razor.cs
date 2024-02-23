using AlsetSoft.CoolFlow.BlazorConcept.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;

namespace AlsetSoft.CoolFlow.BlazorConcept.Web.Pages
{
    public partial class LasersPage
    {
        [Inject] IJSRuntime JSRuntime { get; set; }

        [Inject] LaserService LaserService { get; set; }

        //protected override void OnInitialized()
        //{
        //    List<LaserData> LasersData = LaserService.GetMultiplexorsData(); 
        //}

        //private List<DataItem> Сorrelation(List<LaserData> data) 
        //{

        //}
    }
}
