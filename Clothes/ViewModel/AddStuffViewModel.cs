using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clothes.Annotations;
using Clothes.DB;
using Clothes.Model;
using MessageBox = System.Windows.MessageBox;

namespace Clothes.ViewModel
{
    class AddStuffViewModel : INotifyPropertyChanged, IPageViewModel
    {
        public string Name => "Новая вешь";
        private IDialogService dialogService;

        public List<int> ListOfDegree { get; set; }

        private Stuff _selectedStuff;

        private RelayCommand _addStuff;
        public RelayCommand AddCommand
        {
            get
            {
                return _addStuff ??= new RelayCommand(obj =>
                {
                    if (SelectedStuff.Name != null  & SelectedStuff.Temperature !=null & SelectedStuff.Type != null)
                    {
                        using (ClothesContext Db = new ClothesContext())
                        {
                           // var r = Db.Clothes.FirstOrDefault(x => x.Temperature == 9);
                            Db.Clothes.Add(SelectedStuff);
                            Db.SaveChanges();
                            MessageBox.Show("Вещь успешно добавлена");
                        }
                    }
                });
            }
        }

        private RelayCommand _addPhoto;

        public RelayCommand AddPhoto
        {
            get
            {
                return _addPhoto ??= new RelayCommand(obj =>
                {
                    try
                    {
                        if (dialogService.OpenFileDialog() == true)
                        {
                            string format = Path.GetExtension(dialogService.FilePath);
                            if (format == ".png" | format == ".jpg" | format == "jpeg")
                            {
                                string Path = $"{Application.StartupPath}\\image\\{SelectedStuff.Name}{format}";
                                File.Copy(dialogService.FilePath, Path);
                                SelectedStuff.FilePath = Path;
                            }
                            else
                            {
                                MessageBox.Show("Неверный формат");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dialogService.ShowMessage(ex.Message);
                    }

                });
            }
        }


        public Stuff SelectedStuff
        {
            get => _selectedStuff;
            set { _selectedStuff = value; OnPropertyChanged(); }
        }

        private void Degree()
        {
            ListOfDegree = new List<int>();
            for (int i = -20; i < 35; i++)
            {
                ListOfDegree.Add(i);
            }
        }

        public AddStuffViewModel(IDialogService service)
        {
            dialogService = service;
            Degree();
            _selectedStuff = new Stuff();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
