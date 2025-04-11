using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CharacterConfigurator.Controller;
using CharacterConfigurator.Repository;
using CharacterConfigurator.View;

namespace CharacterConfigurator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        //LoginWindow loginWindow = new LoginWindow();
        //loginWindow.Show();
        //RegisterWindow registerWindow = new RegisterWindow();
        //registerWindow.Show();
        //DbConnection dBConnection = new DbConnection();
        //this.Close();
    }

    private void btnLogOut_Click(object sender, RoutedEventArgs e)
    {
        //MainController.CurrentUser = null;
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
    }

    private void btnPageLeft_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnPageRight_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnNew_Click(object sender, RoutedEventArgs e)
    {
        cmbConsumable.IsEnabled = true;
        cmbWeapon.IsEnabled = true;

        btnPageLeft.Visibility = Visibility.Hidden;
        btnPageRight.Visibility = Visibility.Hidden;

        btnNew.Visibility = Visibility.Hidden;
        btnEdit.Visibility = Visibility.Hidden;
        btnDelete.Visibility = Visibility.Hidden;

        btnCancel.Visibility = Visibility.Visible;
        btnSave.Visibility = Visibility.Visible;
    }

    private void btnEdit_Click(object sender, RoutedEventArgs e)
    {
        cmbConsumable.IsEnabled = true;
        cmbWeapon.IsEnabled = true;

        btnPageLeft.Visibility = Visibility.Hidden;
        btnPageRight.Visibility = Visibility.Hidden;

        btnNew.Visibility = Visibility.Hidden;
        btnEdit.Visibility = Visibility.Hidden;
        btnDelete.Visibility = Visibility.Hidden;

        btnCancel.Visibility = Visibility.Visible;
        btnSave.Visibility = Visibility.Visible;
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        cmbConsumable.IsEnabled = false;
        cmbWeapon.IsEnabled = false;

        btnPageLeft.Visibility = Visibility.Visible;
        btnPageRight.Visibility = Visibility.Visible;

        btnNew.Visibility = Visibility.Visible;
        btnEdit.Visibility = Visibility.Visible;
        btnDelete.Visibility = Visibility.Visible;

        btnCancel.Visibility = Visibility.Hidden;
        btnSave.Visibility = Visibility.Hidden;

    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        cmbConsumable.IsEnabled = false;
        cmbWeapon.IsEnabled = false;

        btnPageLeft.Visibility = Visibility.Visible;
        btnPageRight.Visibility = Visibility.Visible;

        btnNew.Visibility = Visibility.Visible;
        btnEdit.Visibility = Visibility.Visible;
        btnDelete.Visibility = Visibility.Visible;

        btnCancel.Visibility = Visibility.Hidden;
        btnSave.Visibility = Visibility.Hidden;
    }
}