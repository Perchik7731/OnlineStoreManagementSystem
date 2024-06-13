using OnlineStoreManagementSystem.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStoreManagementSystem
{
    public partial class DeliveryPointWindow : Window
    {
        private int _indexPoint;

        public int IDUser { get; set; } = 4;

        OnlineStoreDataBase dataBase = new OnlineStoreDataBase();

        public DeliveryPointWindow()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            DeliveryPointsGrid.ItemsSource = dataBase.AdressPoints.ToList();
        }

        private void CompleteTotalOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Orders order = new Orders()
                {
                    idUser = 1,
                    idStatus = 1,
                    idPoint = _indexPoint + 1
                };
                dataBase.Orders.Add(order);
                dataBase.SaveChanges();
                MessageBox.Show("Заказ успешно оформлен и оплачен!");
                MessageBox.Show("Сейчас выведится ваш трек-номер! Пожалуйста запишите его!");
                MessageBox.Show($"Ваш трек-номер: {order.idOrder}");
            }
            catch
            {
                MessageBox.Show("Пройзошла ошибка!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            BasketWindow basketWindow = new BasketWindow();
            basketWindow.Show();
            Close();
        }

        private void DeliveryPointsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _indexPoint = DeliveryPointsGrid.SelectedIndex;
        }
    }
}
