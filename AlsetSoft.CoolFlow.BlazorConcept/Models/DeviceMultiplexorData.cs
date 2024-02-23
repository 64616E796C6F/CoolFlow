using AlsetSoft.CoolFlow.BlazorConcept.Models.Base;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlsetSoft.CoolFlow.BlazorConcept.Models
{
    public class DeviceMultiplexorData : INotifyPropertyChanged
    {
        private List<Multiplexor> data;

        public int DeviceId { get; set; }
        public List<Multiplexor> Data
        {
            get => data; 
            set
            {
                data = value;
                NotifyPropertyChanged(nameof(Data));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
