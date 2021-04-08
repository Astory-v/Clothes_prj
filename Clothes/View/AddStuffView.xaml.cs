using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Clothes.Model;
using Clothes.ViewModel;

namespace Clothes.View
{
    /// <summary>
    /// Логика взаимодействия для AddStuffView.xaml
    /// </summary>
    public partial class AddStuffView : UserControl
    {
        public AddStuffView()
        {
            InitializeComponent();
            DataContext = new AddStuffViewModel(new PictureDialogService());
        }
    }
}
