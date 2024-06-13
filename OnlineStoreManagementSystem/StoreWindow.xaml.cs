using OnlineStoreManagementSystem.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStoreManagementSystem
{
    public partial class StoreWindow : Window
    {
        public int IDUser { get; set; } = 4;

        OnlineStoreDataBase dataBase = new OnlineStoreDataBase();

        public StoreWindow()
        {
            InitializeComponent();
            DataLoad();
            OpenAdminWindow.Visibility = Visibility.Hidden;
            OpenManagerWindow.Visibility = Visibility.Hidden;
            OpenOperatorWindow.Visibility = Visibility.Hidden;
        }

        public void DataLoad()
        {
            try
            {
                ProductsGrid.ItemsSource = dataBase.Products.ToList();
            }
            catch
            {
                MessageBox.Show("При загрузке данных произошла ошибка!");
            }
        }

        private void OpenAdminWindow_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }

        private void OpenManagerWindow_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            Close();
        }

        private void OpenOperatorWindow_Click(object sender, RoutedEventArgs e)
        {
            OperatorWindow operatorWindow = new OperatorWindow();
            operatorWindow.Show();
            Close();
        }

        private void TrackTheOrder_Click(object sender, RoutedEventArgs e)
        {
            TrackTheOrderWindow trackTheOrderWindow = new TrackTheOrderWindow();
            trackTheOrderWindow.Show();
            Close();
        }

        private void GetProduct_Click(object sender, RoutedEventArgs e)
        {
            var p = ProductsGrid.SelectedItem as Products;

            if(IDUser != 4)
            {
                var o = dataBase.Basket.Where(z => z.idUser == IDUser).Select(z => z.idBasket).Single();
                try
                {
                    var b = dataBase.BasketProducts.Where(x => x.idProduct == p.idProduct && x.idBasket == o).Single();
                    b.Count++;
                    dataBase.SaveChanges();
                    MessageBox.Show("Продукт добавлен в корзину!");
                }
                catch
                {
                    BasketProducts basketproduct = new BasketProducts()
                    {
                        idBasket = o,
                        idProduct = p.idProduct,
                        Count = 1,
                        Price = p.PriceProduct
                    };
                    dataBase.BasketProducts.Add(basketproduct);
                    dataBase.SaveChanges();
                }
            }
            else
            {
                try
                {
                    var b = dataBase.BasketProducts.Where(x => x.idProduct == p.idProduct && x.idBasket == 1).Single();
                    b.Count++;
                    dataBase.SaveChanges();
                }
                catch
                {
                    BasketProducts basketproduct = new BasketProducts()
                    {
                        idBasket = 1,
                        idProduct = p.idProduct,
                        Count = 1,
                        Price = p.PriceProduct
                    };
                    dataBase.BasketProducts.Add(basketproduct);
                    dataBase.SaveChanges();
                }
            }
        }

        private void OpenBasket_Click(object sender, RoutedEventArgs e)
        {
            BasketWindow basketWindow = new BasketWindow();
            var o = dataBase.Basket.Where(z => z.idUser == IDUser).Select(z => z.idBasket).Single();
            basketWindow.idBasket = o;
            basketWindow.Show();
            Close();
        }

        private void SearchProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductsGrid.ItemsSource = dataBase.Products.Where(x => x.NameProduct == NameYourProduct.Text).ToList();
        }

        private void ExitFromAccount_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
