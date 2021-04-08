using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Clothes.Annotations;
using Clothes.DB;
using Clothes.Model;

namespace Clothes.ViewModel
{
    public class DailyDressViewModel : INotifyPropertyChanged, IPageViewModel
    {
        public string Name => "Подобрать вещи";
        private WeatherApi api = new WeatherApi();
        private ObservableCollection<Stuff> _outerwears;

        public ObservableCollection<Stuff> OuterWears
        {
            get => _outerwears; 
            set
            { 
                _outerwears = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Stuff> _pants;

        public ObservableCollection<Stuff> Pants
        {
            get => _pants;
            set
            {
                _pants = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Stuff> _footwear;

        public ObservableCollection<Stuff> Footwear
        {
            get => _footwear;
            set
            {
                _footwear = value;
                OnPropertyChanged();
            }
        }
        public Stuff SelectedStuff
        {
            get;
            set;
        }



        private WeatherResponse _weather;

        public WeatherResponse Weather
        {
            get => _weather;

        }


        public DailyDressViewModel()
        {
            _weather = api.GetWeather();
            GetStuffByTemp();
        }

        private void GetStuffByTemp()
        {
            using (ClothesContext db = new ClothesContext())
            {
                OuterWears = new ObservableCollection<Stuff>(db.Clothes.Where(x => x.Type == "Верхняя одежда" && x.Temperature >= (Weather.Main.Temp - 5) && x.Temperature <= (Weather.Main.Temp + 5)));
                Pants = new ObservableCollection<Stuff>(db.Clothes.Where(x => x.Type == "Штаны" && x.Temperature >= (Weather.Main.Temp - 6) && x.Temperature <= (Weather.Main.Temp + 6)));
                Footwear = new ObservableCollection<Stuff>(db.Clothes.Where(x => x.Type == "Обувь" && x.Temperature >= (Weather.Main.Temp - 7) && x.Temperature <= (Weather.Main.Temp + 7)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}