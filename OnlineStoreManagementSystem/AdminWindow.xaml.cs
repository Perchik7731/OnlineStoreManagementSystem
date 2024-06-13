using System.Windows;

namespace OnlineStoreManagementSystem
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void OpenUsersWindow_Click(object sender, RoutedEventArgs e)
        {
            UsersEditorWindow usersEditorWindow = new UsersEditorWindow();
            usersEditorWindow.Show();
            Close();
        }

        private void OpenProductsWindow_Click(object sender, RoutedEventArgs e)
        {
            ProductsEditorWindow productsEditorWindow = new ProductsEditorWindow();
            productsEditorWindow.Show();
            Close();
        }

        private void OpenReportsWindow_Click(object sender, RoutedEventArgs e)
        {
            ShowReportssWindow showReports = new ShowReportssWindow();
            showReports.Show();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow storeWindow = new StoreWindow();
            storeWindow.Show();
            Close();
        }
    }
}
