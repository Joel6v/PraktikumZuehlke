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
        if (MainController.Character.Count() == 1)
        {
            btnPageRight.IsEnabled = false;
            btnPageLeft.IsEnabled = false;

            CurrentCharaterIndex = 0;
        }else if(MainController.Character.Count() > 1)
        {
            btnPageRight.Focus();
            btnPageLeft.IsEnabled = false;

            CurrentCharaterIndex = 0;
        }
        else
        {
            btnPageRight.IsEnabled = false;
            btnPageLeft.IsEnabled = false;

            btnNew.Focus();
            btnDelete.IsEnabled = false;
            btnEdit.IsEnabled = false;
            //CurrentCharaterIndex = -1; //is set in the top
        }
    }

    private void LoadUiCharacter()
    {
        if (CurrentCharaterIndex != -1)
        {
            //ComboBoxes
            cmbConsumable.SelectedIndex = MainController.Consumable.GetIndex(MainController.Character.Get(CurrentCharaterIndex).Consumable);
            cmbWeapon.SelectedIndex = MainController.Weapon.GetIndex(MainController.Character.Get(CurrentCharaterIndex).Weapon);

            //StatsField
            prgHealth.Value = MainController.Character.Get(CurrentCharaterIndex).Race.Health;
            prgMagicka.Value = MainController.Character.Get(CurrentCharaterIndex).Race.Magicka;
            prgStamina.Value = MainController.Character.Get(CurrentCharaterIndex).Race.Stamina;
            txtblDefense.Text = MainController.Character.Get(CurrentCharaterIndex).GetWholeAmountDefense().ToString();
            txtblDamage.Text = MainController.Character.Get(CurrentCharaterIndex).Weapon.DamagePerHit.ToString();
            txtblAtkSpeed.Text = MainController.Character.Get(CurrentCharaterIndex).Weapon.AttackSpeed.GetStringValue();
            txtblSkill.Text = MainController.Character.Get(CurrentCharaterIndex).Race.Skill.GetStringValue();
        }
    }

    private void btnLogOut_Click(object sender, RoutedEventArgs e)
    {
        MainController.User.Logout();
        new LoginWindow().Show();
        this.Close();
    }

    private void btnPageLeft_Click(object sender, RoutedEventArgs e)
    {
        CurrentCharaterIndex--;
        if (CurrentCharaterIndex <= 0) 
        {
            btnPageLeft.IsEnabled = false;
        }

        btnPageLeft.IsEnabled = true;
    }

    private void btnPageRight_Click(object sender, RoutedEventArgs e)
    {
        CurrentCharaterIndex++;
        if(CurrentCharaterIndex >= MainController.Character.Count()-1) //Pay attention, index vs count
        {
            btnPageRight.IsEnabled = false;
        }

        btnPageLeft.IsEnabled = true;
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
        if (CurrentCharaterIndex != -1) 
        {
            MainController.Character.Delete(CurrentCharaterIndex);
            CheckAmountCharacter();
            LoadUiCharacter();
        }
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
}