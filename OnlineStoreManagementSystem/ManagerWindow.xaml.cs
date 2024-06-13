using System.Windows;

namespace OnlineStoreManagementSystem
{
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void OpenInformationWindow_Click(object sender, RoutedEventArgs e)
        {
            InformationWindow informationWindow = new InformationWindow();
            informationWindow.Show();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow storeWindow = new StoreWindow();
            storeWindow.Show();
            Close();
        }

        private void OpenReportsWindow_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reportsWindow = new ReportsWindow();
            reportsWindow.Show();
            Close();
        }
    }
}
