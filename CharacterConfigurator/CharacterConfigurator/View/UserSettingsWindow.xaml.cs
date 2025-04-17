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
        private string newUsername = string.Empty;
        private string newPassword = string.Empty;

        public UserSettingsWindow()
        {
            InitializeComponent();
            LoadUiStatic();
        }

        private void LoadUiStatic()
        {
            lblUsername.Content = MainController.User.CurrentUser.Name;
            txtChangeUsername.Text = MainController.User.CurrentUser.Name;
            txtblAccountCreationDate.Text = MainController.User.CurrentUser.TimeStamp.ToString(DataHandler.FormatCurrent);
            txtChangeUsername.IsEnabled = false;
            txtChangePassword.IsEnabled = false;
            btnSettingsSave.IsEnabled = false;
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
            btnSettingsSave.IsEnabled = false;
            User changedUser = MainController.User.CurrentUser;

            if (txtChangeUsername.IsEnabled)
            {
                txtChangeUsername.IsEnabled = false;
                changedUser.Name = txtChangeUsername.Text;
            }


            if (txtChangePassword.IsEnabled)
            {
               txtChangePassword.IsEnabled = false;
               changedUser.SetPasswordStr(txtChangePassword.Text);
            }

            bool error = false;
            try
            {
                MainController.User.Update(changedUser);
            }
            catch (ExceptionAlreadyExistingName ex)
            {
                MessageBox.Show(ex.Message);
                error = true;
            }
            catch (ExceptionInvalidLetters ex)
            {
                MessageBox.Show(ex.Message);
                error = true;
            }
            catch (ExceptionNameLength ex)
            {
                MessageBox.Show(ex.Message);
                error = true;
            }


            if (!error)
            {
                DialogResult = true;
                Close();
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
            btnSettingsSave.IsEnabled = (txtChangeUsername.IsEnabled || txtChangePassword.IsEnabled) ? true : false;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            txtChangePassword.IsEnabled = !txtChangePassword.IsEnabled;
            btnSettingsSave.IsEnabled = (txtChangeUsername.IsEnabled || txtChangePassword.IsEnabled) ? true : false;
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
