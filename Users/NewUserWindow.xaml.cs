using MahApps.Metro.Controls;
using System.Windows;

namespace Users
{
    public partial class NewUserWindow : MetroWindow
    {
        public Zakazi Zakaz { get; set; }
        public NewUserWindow(Zakazi z)
        {
            InitializeComponent();
            Zakaz = z;
            this.DataContext = Zakaz;
            this.textbox.Focus();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
