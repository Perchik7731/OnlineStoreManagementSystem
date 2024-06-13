using OnlineStoreManagementSystem.DataBase;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStoreManagementSystem
{
    public partial class UsersEditorWindow : Window
    {
        private int _indexRole;

        OnlineStoreDataBase dataBase = new OnlineStoreDataBase();
        public UsersEditorWindow()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            UsersGrid.ItemsSource = dataBase.Users.ToList();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users user = new Users()
                {
                    Login = YourLogin.Text,
                    Password = YourPassword.Text,
                    idRole = _indexRole + 1,
                    ContactInfo = YourContacts.Text
                };
                dataBase.Users.Add(user);
                dataBase.SaveChanges();
                DataLoad();
                MessageBox.Show("Пользователь добавлен");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var delete = UsersGrid.SelectedItem as Users;
                dataBase.Users.Remove(delete);
                dataBase.SaveChanges();
                DataLoad();
                MessageBox.Show("Пользователь удалён!");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var update = UsersGrid.SelectedItem as Users;
                update.Login = YourLogin.Text;
                update.Password = YourPassword.Text;
                update.idRole = _indexRole;
                update.ContactInfo = YourContacts.Text;
                dataBase.Users.AddOrUpdate(update);
                dataBase.SaveChanges();
                DataLoad();
                MessageBox.Show("Пользователь обновлён!");
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

        private void UsersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Users select = UsersGrid.SelectedItem as Users;
                YourLogin.Text = select.Login;
                YourPassword.Text = select.Password;
                _indexRole = select.idRole;
                RolesBox.Text = select.Roles.NameRole;
                YourContacts.Text = select.ContactInfo;
            }
            catch
            {
                MessageBox.Show("Нажмите (Ок)");
            }
        }

        private void RolesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _indexRole = RolesBox.SelectedIndex;
        }
    }
}
