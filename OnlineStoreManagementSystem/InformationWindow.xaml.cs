using OnlineStoreManagementSystem.DataBase;
using System.Linq;
using System.Windows;

namespace OnlineStoreManagementSystem
{
    public partial class InformationWindow : Window
    {
        OnlineStoreDataBase dataBase = new OnlineStoreDataBase();

        public InformationWindow()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            UsersGrid.ItemsSource = dataBase.Users.ToList();
            ProductsGrid.ItemsSource = dataBase.Products.ToList();
            OrdersGrid.ItemsSource = dataBase.Orders.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            Close();
        }
    }
}
