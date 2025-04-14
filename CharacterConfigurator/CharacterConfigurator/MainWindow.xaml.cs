using System.Drawing;
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
using CharacterConfigurator.Model;
using CharacterConfigurator.Model.CharacterEnum;
using CharacterConfigurator.View;

namespace CharacterConfigurator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int CurrentCharaterIndex = -1;
    
    public MainWindow()
    {
        InitializeComponent();
        LoadUiStatic();
        CheckAmountCharacter();
        LoadUiCharacter();
        SetDisabledElements();

        //LoginWindow loginWindow = new LoginWindow();
        //loginWindow.Show();
        //RegisterWindow registerWindow = new RegisterWindow();
        //registerWindow.Show();
        //DbConnection dBConnection = new DbConnection();
        //this.Close();
    }

    private void LoadUiStatic() //For ComboBoxes and so
    {
        for (int i = 0; i < MainController.Consumable.Count(); i++)
        {
            cmbConsumable.Items.Add(MainController.Consumable.Get(i).Name);
        }
        for (int i = 0; i < MainController.Weapon.Count(); i++)
        {
            cmbWeapon.Items.Add(MainController.Weapon.Get(i).Name);
        }
        for (int i = 0; i < MainController.Clothing.GetAllFromType(ClothingType.HEADGEAR).Count; i++)
        {
            
        }
    }

    private void CheckAmountCharacter()
    {
        if (MainController.Character.Count() > 0)
        {
            btnPageRight.Focus();
            CurrentCharaterIndex = 0;
        }
        else
        {
            btnNew.Focus();
        }
    }

    private void LoadUiCharacter()
    {
        if (CurrentCharaterIndex != -1)
        {

        }
    }

    private void btnLogOut_Click(object sender, RoutedEventArgs e)
    {
        MainController.User.Logout();
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
        SetEnabledElements();
    }

    private void btnEdit_Click(object sender, RoutedEventArgs e)
    {
        SetEnabledElements();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        MainController.Character.Delete(CurrentCharaterIndex);
        CheckAmountCharacter();
        LoadUiCharacter();
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        SetDisabledElements();
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
       SetDisabledElements();
    }

    private void cmbConsumable_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbConsumable.SelectedIndex >= 0)
        {
            txtblConsumable.Visibility = Visibility.Hidden;
        }

        imgConsumable.Source = MainController.Consumable.Get(cmbConsumable.SelectedIndex).GetFullPathImage();
    }

    private void cmbWeapon_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbWeapon.SelectedIndex >= 0)
        {
            txtblWeapon.Visibility = Visibility.Hidden;
        }
    }

    private void cmbHeadgear_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbHeadgear.SelectedIndex >= 0)
        {
            txtblHeadgear.Visibility = Visibility.Hidden;
        }
    }

    private void cmbChest_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbChest.SelectedIndex >= 0)
        {
            txtblChest.Visibility = Visibility.Hidden;
        }
    }

    private void cmbGloves_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if ( cmbGloves.SelectedIndex >= 0)
        {
            txtblGloves.Visibility = Visibility.Hidden;
        }
    }

    private void cmbLegs_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbLegs.SelectedIndex >= 0)
        {
            txtblLegs.Visibility = Visibility.Hidden;
        }
    }

    private void cmbRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbRace.SelectedIndex >= 0)
        {
            txtblRace.Visibility = Visibility.Hidden;
        }
    }

    private void cmbSex_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbSex.SelectedIndex >= 0)
        {
            txtblSex.Visibility = Visibility.Hidden;
        }
    }

    private void SetEnabledElements()
    {
        cmbConsumable.IsEnabled = true;
        cmbWeapon.IsEnabled = true;
        cmbHeadgear.IsEnabled = true;
        cmbChest.IsEnabled = true;
        cmbGloves.IsEnabled = true;
        cmbLegs.IsEnabled = true;
        cmbRace.IsEnabled = true;
        cmbSex.IsEnabled = true;
        txtCharacterName.IsEnabled = true;

        btnPageLeft.Visibility = Visibility.Hidden;
        btnPageRight.Visibility = Visibility.Hidden;

        btnNew.Visibility = Visibility.Hidden;
        btnEdit.Visibility = Visibility.Hidden;
        btnDelete.Visibility = Visibility.Hidden;

        btnCancel.Visibility = Visibility.Visible;
        btnSave.Visibility = Visibility.Visible;
    }

    private void SetDisabledElements()
    {
        cmbConsumable.IsEnabled = false;
        cmbWeapon.IsEnabled = false;
        cmbHeadgear.IsEnabled = false;
        cmbChest.IsEnabled = false;
        cmbGloves.IsEnabled = false;
        cmbLegs.IsEnabled = false;
        cmbRace.IsEnabled = false;
        cmbSex.IsEnabled = false;
        txtCharacterName.IsEnabled = false;

        btnPageLeft.Visibility = Visibility.Visible;
        btnPageRight.Visibility = Visibility.Visible;

        btnNew.Visibility = Visibility.Visible;
        btnEdit.Visibility = Visibility.Visible;
        btnDelete.Visibility = Visibility.Visible;

        btnCancel.Visibility = Visibility.Hidden;
        btnSave.Visibility = Visibility.Hidden;
    }
}