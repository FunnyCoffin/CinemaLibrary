using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaLibrary.bd;

namespace CinemaLibrary.pagee
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Entities entities = new Entities();
        public Login()
        {
            InitializeComponent();
           
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Проверка учетных данных
            var user = Entities.GetContext().Users.SingleOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Если учетные данные верны, выполните действия после успешной авторизации
                MessageBox.Show("Login successful. User ID: " + user.UserID);
                NavigationService.Navigate(new Lists(user));
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Check());
        }
    }
}
