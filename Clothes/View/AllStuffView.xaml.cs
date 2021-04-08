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
using Clothes.ViewModel;

namespace Clothes.View
{
    /// <summary>
    /// Логика взаимодействия для AllStuffView.xaml
    /// </summary>
    public partial class AllStuffView : UserControl
    {
        public AllStuffView()
        {
            InitializeComponent();
            DataContext = new AllStuffViewModel();
        }
    }
}
