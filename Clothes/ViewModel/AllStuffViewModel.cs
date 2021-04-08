using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Clothes.Annotations;
using Clothes.DB;
using Clothes.Model;

namespace Clothes.ViewModel
{
    public class AllStuffViewModel : INotifyPropertyChanged, IPageViewModel

    {
        
        public string Name => "Все вещи";
        private ObservableCollection<Stuff> _clothes;
        private RelayCommand _deleteStuffCommand;
        public Stuff SelectedStuff { get; set; }

        private void Ads()
        {

        }
        public RelayCommand DeleteStuffCommand
        {
            get
            {
                return _deleteStuffCommand ??= new RelayCommand(obj =>
                {
                    try
                    {

                        using (ClothesContext db = new ClothesContext())
                        {
                            Thread treaad = new Thread(Ads, 1);
                            Stuff deletedStuff = db.Clothes.FirstOrDefault(o => o.id == SelectedStuff.id);
                            db.Clothes.Remove(deletedStuff);
                            Clothes.Remove(SelectedStuff);
                            db.SaveChanges();
                        }




                    }
                    catch
                    {

                    }
                   
                });
            }
        }

        public ObservableCollection<Stuff> Clothes
        {
            get => _clothes;
            set { _clothes = value; OnPropertyChanged("Clothes"); }
        }

        private void GetClothes()
        {
            using (ClothesContext db = new ClothesContext())
            {
                Clothes  = new ObservableCollection<Stuff>(db.Clothes.OrderBy(x=>x.Type).ToList());db.Clothes.OrderBy(x=>x.Type).ToList();
            }
        }

        public AllStuffViewModel()
        {
            GetClothes();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}