using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Licenta2.Models;
using Licenta2.Views;
using Licenta2.Services;

namespace Licenta2.ViewModels
{
    public class RegiuniMontaneViewModel : BaseViewModel
    {
        public ObservableCollection<RegiuneMontana> RegiuniMontane { get; set; }
        public Command LoadRegiuniMontaneCommand { get; set; }

        public RegiuniMontaneViewModel()
        {
            RegiuniMontane = new ObservableCollection<RegiuneMontana>();
            LoadRegiuniMontaneCommand = new Command(async () => await ExecuteLoadRegiuniMontaneCommand());

        }

        public async Task ExecuteLoadRegiuniMontaneCommand()
        {
            IsBusy = true;

            try
            {
                RegiuniMontane.Clear();
                var regiuniMontane = await App.RegiuneMontanaDatabase.GetRegiuniMontaneAsync();
                foreach (var regiuneMontana in regiuniMontane)
                {
                    RegiuniMontane.Add(regiuneMontana);
                }
                foreach(var regiuneMontana in RegiuniData.RegiuniDate)
                {
                    RegiuniMontane.Add(regiuneMontana);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}