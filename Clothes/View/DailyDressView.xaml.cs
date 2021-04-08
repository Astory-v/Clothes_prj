using Clothes.ViewModel;
using System.Windows.Controls;

namespace Clothes.View
{
    /// <summary>
    /// Логика взаимодействия для DailyDressView.xaml
    /// </summary>
    public partial class DailyDressView : UserControl
    {
        public DailyDressView()
        {
            InitializeComponent();
            DataContext = new DailyDressViewModel();
        }
    }
}
