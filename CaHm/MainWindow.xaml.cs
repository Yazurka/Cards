using MahApps.Metro.Controls;
using CaHm.ViewModel;

namespace CaHm
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
