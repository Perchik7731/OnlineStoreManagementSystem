using OnlineStoreManagementSystem.DataBase;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStoreManagementSystem
{
    public partial class OperatorWindow : Window
    {
        private int _indexStatus;

        OnlineStoreDataBase dataBase = new OnlineStoreDataBase();

        public OperatorWindow()
        {
            InitializeComponent();
            OrdersLoad();
            UsersLoad();
        }

        public void OrdersLoad()
        {
            OrdersGrid.ItemsSource = dataBase.Orders.ToList();
        }

        public void UsersLoad()
        {
            UsersGrid.ItemsSource = dataBase.Users.ToList();
        }

        private void UpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var update = OrdersGrid.SelectedItem as Orders;
                update.idStatus = _indexStatus + 1;
                dataBase.Orders.AddOrUpdate(update);
                dataBase.SaveChanges();
                OrdersLoad();
                MessageBox.Show("Статус заказа обновлён!");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow storeWindow = new StoreWindow();
            storeWindow.Show();
            Close();
        }

        private void StatusOrderBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _indexStatus = StatusOrderBox.SelectedIndex;
        }
    }
}
