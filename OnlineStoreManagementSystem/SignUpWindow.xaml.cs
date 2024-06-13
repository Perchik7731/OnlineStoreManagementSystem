using OnlineStoreManagementSystem.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStoreManagementSystem
{
    public partial class SignUpWindow : Window
    {
        private int _indexValue;

        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            using(OnlineStoreDataBase dataBase = new OnlineStoreDataBase())
            {
                try
                {
                    Users users = new Users()
                    {
                        Login = YourLogin.Text,
                        Password = YourPassword.Text,
                        idRole = _indexValue + 1,
                        ContactInfo = ContactInformation.Text
                    };
                    dataBase.Users.Add(users);
                    dataBase.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались!");

                    var userBasket = dataBase.Users.Where(p => p.Login == YourLogin.Text && p.Password == YourPassword.Text).Select(p => p.idUser).Single();

                    Basket basket = new Basket()
                    {
                        idUser = userBasket
                    };
                    dataBase.Basket.Add(basket);
                    dataBase.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка!");
                }
            };
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void RolesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _indexValue = RolesBox.SelectedIndex;
        }
    }
}
