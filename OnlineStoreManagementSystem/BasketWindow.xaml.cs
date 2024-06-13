using OnlineStoreManagementSystem.DataBase;
using System.Linq;
using System.Windows;

namespace OnlineStoreManagementSystem
{
    public partial class BasketWindow : Window
    {
        public int idBasket { get; set; } = 1;
        OnlineStoreDataBase dataBase = new OnlineStoreDataBase();
        public BasketWindow()
        {
            InitializeComponent();
            BasketDataLoad();
        }

        public void BasketDataLoad()
        {
            BasketGrid.ItemsSource = dataBase.BasketProducts.Where(p => p.idBasket == idBasket).ToList();
        }

        private void CompleteOrder_Click(object sender, RoutedEventArgs e)
        {
            DeliveryPointWindow deliveryPointWindow = new DeliveryPointWindow();
            deliveryPointWindow.Show();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow storeWindow = new StoreWindow();
            storeWindow.Show();
            Close();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var d = BasketGrid.SelectedItem as BasketProducts;
            dataBase.BasketProducts.Remove(d);
            BasketDataLoad();
            dataBase.SaveChanges();
        }
    }
}
