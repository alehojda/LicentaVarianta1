using DescoperaMuntii.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DescoperaMuntii.ViewModels;

namespace DescoperaMuntii.ViewModels
{
    public class RegiuniMontaneViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public RegiuniMontaneViewModel() { }

        public RegiuniMontaneViewModel(RegiuniMontane regiuniMontane)
        {
            Id = regiuniMontane.Id;
            _regiune = regiuniMontane.Regiune;
            _varf = regiuniMontane.Varf;
            _vreme = regiuniMontane.Vreme;
            _comentarii = regiuniMontane.Comentarii;
        }

        private string _regiune;
        public string Regiune
        {
            get { return _regiune; }
            set
            {
                SetValue(ref _regiune, value);
               
            }
        }

        private string _varf;
        public string Varf
        {
            get
            { return _varf; }
            set
            {
                SetValue(ref _varf, value);
            }
        }

        private string _vreme;
        public string Vreme
        {
            get { return _vreme; }
            set
            { SetValue(ref _vreme, value); }
        }

        private string _comentarii;
        public string Comentarii
        {
            get { return _comentarii; }
            set
            { SetValue(ref _comentarii, value); }
        }
    }
}
