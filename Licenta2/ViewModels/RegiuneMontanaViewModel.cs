using System;

using Licenta2.Models;

namespace Licenta2.ViewModels
{
    public class RegiuneMontanaViewModel : BaseViewModel
    {
        public RegiuneMontana RegiuneMontana { get; set; }
        public ComentariiViewModel ComentariiViewModel { get; set; }
        public RegiuneMontanaViewModel(RegiuneMontana RegiuneMontana = null)
        {
            Title = RegiuneMontana?.Nume;
            this.RegiuneMontana = RegiuneMontana;
            this.ComentariiViewModel = new ComentariiViewModel(RegiuneMontana.Id);
        }
    }
}
