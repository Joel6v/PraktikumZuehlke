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
    /// Interaction logic for UserSettingsWindow.xaml
    /// </summary>
    public partial class UserSettingsWindow : Window
    {
        User changedUser = MainController.User.CurrentUser;

        public UserSettingsWindow()
        {
            InitializeComponent();
            LoadUiStatic();
        }

        private void LoadUiStatic()
        {
            lblUsername.Content = MainController.User.CurrentUser.Name;
            txtChangeUsername.Text = MainController.User.CurrentUser.Name;
            txtblAccountCreationDate.Text = MainController.User.CurrentUser.TimeStamp.ToString(DataHandler.Format);
            txtChangeUsername.IsEnabled = false;
            txtChangePassword.IsEnabled = false;
        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult  accountDeletion = MessageBox.Show("Are you sure you want to delete your account?","Account deletion",MessageBoxButton.YesNo,MessageBoxImage.Error);

            if (accountDeletion == MessageBoxResult.Yes) 
            {
                MainController.User.Delete();
                DialogResult = false;
                Close();
            }
        }

        private void btnSettingsCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnSettingsSave_Click(object sender, RoutedEventArgs e)
        {
            bool errorUsername = false;
            try
            {
                changedUser.Name = txtChangeUsername.Text;
            }
            catch (ExceptionAlreadyExistingName ex)
            {
                MessageBox.Show(ex.Message);
                errorUsername = true;
            }
            catch (ExceptionInvalidLetters ex)
            {
                MessageBox.Show(ex.Message);
                errorUsername = true;
            }
            catch (ExceptionNameLength ex)
            {
                MessageBox.Show(ex.Message);
                errorUsername = true;
            }

            bool errorPassword = false;
            try
            {
                changedUser.SetPasswordStr(txtChangePassword.Text);
            }
            catch (ExceptionNameLength ex)
            {
                MessageBox.Show(ex.Message);
                errorPassword = true;
            }

            if (!errorUsername && !errorPassword)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                btnSettingsSave.IsEnabled = false;
            }
        }

        private void btnChangeProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDeleteProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnChangeUsername_Click(object sender, RoutedEventArgs e)
        {
            txtChangeUsername.IsEnabled = !txtChangeUsername.IsEnabled;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            txtChangePassword.IsEnabled = !txtChangePassword.IsEnabled;
        }

        private void radLightMode_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radDarkMode_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radGreyMode_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = (this.DialogResult == null) ? true : this.DialogResult;
        }
    }
}
