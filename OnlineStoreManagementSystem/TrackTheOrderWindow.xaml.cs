using OnlineStoreManagementSystem.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnlineStoreManagementSystem
{
    public partial class TrackTheOrderWindow : Window
    {
        public TrackTheOrderWindow()
        {
            InitializeComponent();
        }

        private void SearchOrder_Click(object sender, RoutedEventArgs e)
        {
            int trackValue = Convert.ToInt32(TrackNumber.Text);

            OnlineStoreDataBase dataBase = new OnlineStoreDataBase();
            OrdersGrid.ItemsSource = dataBase.Orders.Where(x => x.idOrder == trackValue).ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow storeWindow = new StoreWindow();
            storeWindow.Show();
            Close();
        }
    }
}
