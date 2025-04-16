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
        public UserSettingsWindow()
        {
            InitializeComponent();
        }

        private void LoadUiStatic()
        {
            lblUsername.Content = MainController.User.CurrentUser.Name;
            txtChangeUsername.Text = MainController.User.CurrentUser.Name;
            txtblAccountCreationDate.Text = MainController.User.CurrentUser.TimeStamp.ToString(DataHandler.Format);
        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult  accountDeletion = MessageBox.Show("Are you sure you want to delete your account?","Account deletion",MessageBoxButton.YesNo,MessageBoxImage.Error);

            if (accountDeletion == MessageBoxResult.Yes) 
            {
                MainController.User.Delete();
                this.DialogResult = false;
                this.Close();                
            }
        }

        private void btnSettingsCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnSettingsSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnChangeProfilePicture_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteProfilePicture_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChangeUsername_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainController.User.CurrentUser.Name = txtChangeUsername.Text;
                MainController.User.Save();
                lblUsername.Content = MainController.User.CurrentUser.Name;
            }
            catch (ExceptionAlreadyExistingName ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ExceptionInvalidLetters ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ExceptionNameLength ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (ExceptionNameLength ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
