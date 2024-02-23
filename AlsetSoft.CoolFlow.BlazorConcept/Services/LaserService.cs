using AlsetSoft.CoolFlow.BlazorConcept.Models;
using System.Collections.ObjectModel;

namespace AlsetSoft.CoolFlow.BlazorConcept.Services
{
    public class LaserService
    {
        private static ObservableCollection<DeviceMultiplexorData> LaserMultiplexorData { get; set; } =
        [
            new() 
            {
                DeviceId = 333,
                Data = 
                [
                    new()
                    {
                        Id = 1,
                        Values = [21, 22, 23, 24, 25]
                    },
                    new()
                    {
                        Id = 2,
                        Values = [21, 22, 23, 24, 25]
                    }
                ]
            }
        ];

        public DeviceMultiplexorData? GetMultiplexorData(int id)
        {
            return LaserMultiplexorData.FirstOrDefault(d => d.DeviceId == id);
        }

        public ObservableCollection<DeviceMultiplexorData> GetMultiplexorsData()
        {
            return LaserMultiplexorData;
        }

        public void SetMultiplexorData(DeviceMultiplexorData data)
        {
            var existingData = LaserMultiplexorData.FirstOrDefault(d => d.DeviceId == data.DeviceId);

            if (existingData != null)
            {
                existingData.Data = data.Data;
            }
            else
            {
                LaserMultiplexorData.Add(data);
            }
        }
    }
}
