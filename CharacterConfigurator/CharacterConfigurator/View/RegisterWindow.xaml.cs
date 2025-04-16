using CharacterConfigurator.Controller;
using CharacterConfigurator.Model;
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
            try
            {
                MainController.User.Add(new Model.User(username, password));
                //new MainWindow().Show();
                Close();
            }
            catch (ExceptionAlreadyExistingName ex)
            {
                lblUsernameTaken.Visibility = Visibility.Visible;
            }
            catch (ExceptionInvalidLetters ex)
            {
                lblUsernameSpecialCharacters.Visibility = Visibility.Visible;
            }
            catch (ExceptionNameLenght ex)
            {
                lblUsernameInvalid.Visibility = Visibility.Visible;
            }

        }

        private void lblRegisterLogin_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }

        private void txtRegisterPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            HiddenLblErrors();
        }

        private void txtRegisterUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            HiddenLblErrors();
        }

        private void HiddenLblErrors()
        {
            lblUsernameTaken.Visibility = Visibility.Hidden;
            lblUsernameSpecialCharacters.Visibility = Visibility.Hidden;
            lblUsernameInvalid.Visibility = Visibility.Hidden;
        }
    }
}
