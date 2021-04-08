using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clothes.Annotations;

namespace Clothes.Model
{
    [Table("Clothes")]
    public class Stuff : INotifyPropertyChanged
    {
        private string _filePath;
        [Key] private string _name;
        public int id { get; set; }
        public string Name { 
            get=>_name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _type;
        public string Type { 
            get=>_type;
            set
            {
                _type = value; OnPropertyChanged(); 

            }
        }

        private double? _temperature;
        public double? Temperature {
            get=>_temperature;
            set { _temperature = value; OnPropertyChanged(); }
        }

        public string FilePath
        {
            get{
                if (_filePath == null)
                {
                    return $"{Application.StartupPath}\\image\\stuff.png";
                }
                else
                {
                    return _filePath;
                }
            }
            set { _filePath = value;  OnPropertyChanged();}
        }
        public Stuff() { }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
