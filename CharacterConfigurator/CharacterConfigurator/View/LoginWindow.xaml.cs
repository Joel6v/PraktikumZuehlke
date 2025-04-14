using Microsoft.VisualBasic;
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
using System.Windows.Threading;
using CharacterConfigurator.Controller;

namespace CharacterConfigurator.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
       
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void txtLoginPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblInvalidLogin.Visibility = Visibility.Hidden;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string password = txtLoginPassword.GetActualText();
            string username = txtLoginUsername.Text;
            MessageBox.Show(password + " " + username);
            if(MainController.User.Validate(txtLoginUsername.Text, password))
            {
                new MainWindow().Show();
                Close();
            }
            else
            {
                lblInvalidLogin.Visibility = Visibility.Visible;
            }
        }

        private void txtLoginUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblInvalidLogin.Visibility = Visibility.Hidden;
        }

        private void lblLoginRegister_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow objRegisterWindow = new RegisterWindow();
            objRegisterWindow.Show();
            this.Close();
        }
    }
}
