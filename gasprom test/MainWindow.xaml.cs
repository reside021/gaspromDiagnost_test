using gasprom_test.Service;
using gasprom_test.ViewModels;
using System.Windows;

namespace gasprom_test
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(new DialogService());
        }
    }
}