using MahApps.Metro.Controls;

namespace Users
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            // Определение данных контекста
            this.DataContext = new MainViewModel();
        }

    }
}
