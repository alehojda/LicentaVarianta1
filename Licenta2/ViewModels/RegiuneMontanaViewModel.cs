using System;

using Licenta2.Models;
using Licenta2.Services;

namespace Licenta2.ViewModels
{
    public class RegiuneMontanaViewModel : BaseViewModel
    {
        public RegiuneMontana RegiuneMontana { get; set; }
        public ComentariiViewModel ComentariiViewModel { get; set; }
        public WeatherViewModel WeatherViewModel { get; set; }

        public RegiuneMontanaViewModel(RegiuneMontana RegiuneMontana = null)
        {
            Title = RegiuneMontana?.Nume;
            this.RegiuneMontana = RegiuneMontana;
            this.ComentariiViewModel = new ComentariiViewModel(RegiuneMontana.Id);
            this.WeatherViewModel = new WeatherViewModel(RegiuneMontana.Locatie);
        }
    }
}
