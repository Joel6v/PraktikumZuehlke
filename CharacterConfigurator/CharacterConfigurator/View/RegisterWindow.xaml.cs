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

namespace CharacterConfigurator.View
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string password = txtRegisterPassword.GetActualText();
            string username = txtRegisterUsername.Text;
            MessageBox.Show(password + " " + username);
        }

        private void txtRegisterPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lblRegisterLogin_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginWindow objLoginWindow = new LoginWindow();
            objLoginWindow.Show();
            this.Close();
        }
    }
}
