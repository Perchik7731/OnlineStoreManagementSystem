using OnlineStoreManagementSystem.DataBase;
using System.Linq;
using System.Windows;

namespace OnlineStoreManagementSystem
{
    public partial class ShowReportssWindow : Window
    {
        public ShowReportssWindow()
        {
            InitializeComponent();
            DataLoad();
        }
        
        public void DataLoad()
        {
            using(OnlineStoreDataBase dataBase = new OnlineStoreDataBase())
            {
                ReportsGrid.ItemsSource = dataBase.Reports.ToList();
            };
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}
