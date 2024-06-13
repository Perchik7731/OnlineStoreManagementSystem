using OnlineStoreManagementSystem.DataBase;
using System.Linq;
using System.Windows;

namespace OnlineStoreManagementSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow storeWindow = new StoreWindow();
            DeliveryPointWindow deliveryPoint = new DeliveryPointWindow();

            using(OnlineStoreDataBase dataBase = new OnlineStoreDataBase())
            {
                var reque = dataBase.Users.Where(p => p.Login == YourLogin.Text && p.Password == YourPassword.Text).ToList();

                if(reque != null)
                {
                    Close();
                    if (reque[0].idRole == 1)
                    {
                        storeWindow.OpenAdminWindow.Visibility = Visibility.Visible;
                    }
                    else if (reque[0].idRole == 2)
                    {
                        storeWindow.OpenManagerWindow.Visibility = Visibility.Visible;
                    }
                    else if (reque[0].idRole == 3)
                    {
                        storeWindow.OpenOperatorWindow.Visibility = Visibility.Visible;
                    }
                    storeWindow.IDUser = reque[0].idUser;
                    deliveryPoint.IDUser = reque[0].idUser;
                    storeWindow.Show();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка!");
                }
            };
        }

        private void OpenSignUpWindow_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            Close();
        }
    }
}
