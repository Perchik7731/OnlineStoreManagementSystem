using OnlineStoreManagementSystem.DataBase;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStoreManagementSystem
{
    public partial class ReportsWindow : Window
    {
        OnlineStoreDataBase dataBase = new OnlineStoreDataBase();
        public ReportsWindow()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            UsersGrid.ItemsSource = dataBase.Users.ToList();
            ProductsGrid.ItemsSource = dataBase.Products.ToList();
            ReportsGrid.ItemsSource = dataBase.Reports.ToList();
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int revenues = Convert.ToInt32(YourRevenues.Text);

                Reports report = new Reports()
                {
                    PopularProduct = YourProduct.Text,
                    ActiveUser = YourUser.Text,
                    TotalRevenues = revenues
                };
                dataBase.Reports.Add(report);
                dataBase.SaveChanges();
                DataLoad();
                MessageBox.Show("Отчёт успешно сгенерирован!");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            Close();
        }

        private void UsersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Users select = UsersGrid.SelectedItem as Users;
            YourUser.Text = select.Login;
        }

        private void ProductsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Products select = ProductsGrid.SelectedItem as Products;
            YourProduct.Text = select.NameProduct;
        }
    }
}
