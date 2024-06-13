using OnlineStoreManagementSystem.DataBase;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStoreManagementSystem
{
    public partial class ProductsEditorWindow : Window
    {

        OnlineStoreDataBase dataBase = new OnlineStoreDataBase();
        public ProductsEditorWindow()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            ProductsGrid.ItemsSource = dataBase.Products.ToList();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int productPrice = int.Parse(YourPriceProduct.Text);

                Products product = new Products()
                {
                    NameProduct = YourNameProduct.Text,
                    PriceProduct = productPrice,
                    DescriptionProduct = YourDescriptionProduct.Text,
                    CategoryProduct = YourCategoryProduct.Text
                };
                dataBase.Products.Add(product);
                dataBase.SaveChanges();
                DataLoad();
                MessageBox.Show("Продукт успешно добавлен!");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var delete = ProductsGrid.SelectedItem as Products;
                dataBase.Products.Remove(delete);
                dataBase.SaveChanges();
                DataLoad();
                MessageBox.Show("Продукт удалён!");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int productPrice = int.Parse(YourPriceProduct.Text);

                Products update = ProductsGrid.SelectedItem as Products;
                update.NameProduct = YourNameProduct.Text;
                update.PriceProduct = productPrice;
                update.DescriptionProduct = YourDescriptionProduct.Text;
                update.CategoryProduct = YourCategoryProduct.Text;
                dataBase.Products.AddOrUpdate(update);
                dataBase.SaveChanges();
                DataLoad();
                MessageBox.Show("Продукт обновлён!");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }

        private void ProductsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Products select = ProductsGrid.SelectedItem as Products;
                YourNameProduct.Text = select.NameProduct;
                YourPriceProduct.Text = select.PriceProduct.ToString();
                YourDescriptionProduct.Text = select.DescriptionProduct;
                YourCategoryProduct.Text = select.CategoryProduct;
            }
            catch
            {
                MessageBox.Show("Нажмите (Ок)");
            }
        }
    }
}
