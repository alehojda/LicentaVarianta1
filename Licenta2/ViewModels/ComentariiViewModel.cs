using Licenta2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Licenta2.ViewModels
{
    public class ComentariiViewModel : BaseViewModel
    { 
        public ObservableCollection<Comentariu> Comentarii { get; set; }
        public Command LoadComentariiCommand { get; set; }
        public Comentariu ComentariuNou { get; set; }
        public int RegiuneMontanaId { get; set; }

        public ComentariiViewModel(int RegiuneMontanaId)
        {
            Comentarii = new ObservableCollection<Comentariu>();
            ComentariuNou = new Comentariu();
            ComentariuNou.RegiuneMontanaId = RegiuneMontanaId;
            this.RegiuneMontanaId = RegiuneMontanaId;
            LoadComentariiCommand = new Command(async () => await ExecuteLoadComentariiCommand());
        }

        public async Task ExecuteLoadComentariiCommand()
        {
            IsBusy = true;

            try
            {
                Comentarii.Clear();
                //cod de cleanup la db
                //await App.ComentariuDatabase.DeleteComentariiAsync();
                //await App.RegiuneMontanaDatabase.DeleteRegiuniMontaneAsync();
                var comentarii = await App.ComentariuDatabase.GetComentariiForRegiuneMontanaAsync(RegiuneMontanaId);
                foreach (var comentariu in comentarii)
                {
                    Comentarii.Add(comentariu);
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

        public void resetComentariuNou()
        {
            this.ComentariuNou = new Comentariu();
            this.ComentariuNou.RegiuneMontanaId = RegiuneMontanaId;
        }
    }
}
