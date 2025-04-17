using CharacterConfigurator.Controller;
using CharacterConfigurator.Model;
using CharacterConfigurator.Model.CharacterEnum;
using CharacterConfigurator.Model.Clothing;
using CharacterConfigurator.View;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace CharacterConfigurator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int CurrentCharaterIndex = -1;
    
    public MainWindow()
    {      

        if(MainController.User != null) 
        {
            InitializeComponent();
            LoadUiStatic();
            CheckAmountCharacter();
            LoadUiCharacter();
            SetDisabledElements();
        }
        else
        {
            MainController.Load();
            new LoginWindow().Show();
            this.Close();
        }
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
        //Start Clothing
        for (int i = 0; i < MainController.Headgear.Count(); i++)
        {
            cmbHeadgear.Items.Add(MainController.Headgear.Get(i).Name);
        }
        for (int i = 0; i < MainController.Chest.Count(); i++)
        {
            cmbChest.Items.Add(MainController.Chest.Get(i).Name);
        }
        for (int i = 0; i < MainController.Gloves.Count(); i++)
        {
            cmbGloves.Items.Add(MainController.Gloves.Get(i).Name);
            string name = MainController.Gloves.Get(i).Name;
        }
        for (int i = 0; i < MainController.Legs.Count(); i++)
        {
            cmbLegs.Items.Add(MainController.Legs.Get(i).Name);
        }
        //End Clothing
        for(int i = 0; i < MainController.Race.Count(); i++)
        {
            cmbRace.Items.Add(MainController.Race.Get(i).Name);
        }
        for(int i = 0; i < Enum.GetNames(typeof(Sex)).Length; i++)
        {
            cmbSex.Items.Add(((Sex)i).GetStringValue());
        }

        //Username
        lblUsername.Content = MainController.User.CurrentUser.Name;
    }

    private void CheckAmountCharacter()
    {
        if (MainController.Character.Count() == 1)
        {
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;

            CurrentCharaterIndex = 0;
        }else if(MainController.Character.Count() > 1)
        {
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;

            btnPageRight.Focus();

            if(CurrentCharaterIndex == -1)
            {
                CurrentCharaterIndex = 0;
            }
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

        CheckPageButtons();
    }

    private bool settingAllCmb = false;
    private void LoadUiCharacter()
    {
        if (CurrentCharaterIndex != -1)
        {
            settingAllCmb = true;
            txtCharacterCreationDate.Text = MainController.Character.Get(CurrentCharaterIndex).Name;
            txtCharacterCreationDate.Text = MainController.Character.Get(CurrentCharaterIndex).TimeStamp.ToString(DataHandler.Format);
            //ComboBoxes
            cmbConsumable.SelectedIndex = MainController.Consumable.GetIndex(MainController.Character.Get(CurrentCharaterIndex).Consumable);
            cmbWeapon.SelectedIndex = MainController.Weapon.GetIndex(MainController.Character.Get(CurrentCharaterIndex).Weapon);
            cmbRace.SelectedIndex = MainController.Race.GetIndex(MainController.Character.Get(CurrentCharaterIndex).Race);
            cmbSex.SelectedIndex = (int)MainController.Character.Get(CurrentCharaterIndex).Sex;
            cmbHeadgear.SelectedIndex = MainController.Headgear.GetIndex(MainController.Character.Get(CurrentCharaterIndex).Headgear);
            cmbChest.SelectedIndex = MainController.Chest.GetIndex(MainController.Character.Get(CurrentCharaterIndex).Chest);
            cmbGloves.SelectedIndex = MainController.Gloves.GetIndex(MainController.Character.Get(CurrentCharaterIndex).Gloves);
            cmbLegs.SelectedIndex = MainController.Legs.GetIndex(MainController.Character.Get(CurrentCharaterIndex).Legs);
            settingAllCmb = false;
            CalcStatsField();

            //StatsField
            //prgHealth.Value = MainController.Character.Get(CurrentCharaterIndex).Race.Health;
            //prgMagicka.Value = MainController.Character.Get(CurrentCharaterIndex).Race.Magicka;
            //prgStamina.Value = MainController.Character.Get(CurrentCharaterIndex).Race.Stamina;
            //txtblDefense.Text = MainController.Character.Get(CurrentCharaterIndex).GetWholeAmountDefense().ToString();
            //txtblDamage.Text = MainController.Character.Get(CurrentCharaterIndex).Weapon.DamagePerHit.ToString();
            //txtblAtkSpeed.Text = MainController.Character.Get(CurrentCharaterIndex).Weapon.AttackSpeed.GetStringValue();
            //txtblSkill.Text = MainController.Character.Get(CurrentCharaterIndex).Race.Skill.GetStringValue();
        }
        else
        {
            LoadUiDefaultCharacter();
        }
    }

    private void LoadUiDefaultCharacter()
    {
        txtCharacterName.Text = "character name";
        txtCharacterCreationDate.Text = "dd.mm.yyyy hh:mm:ss";
        //ComboBoxes
        settingAllCmb = true;
        cmbConsumable.SelectedIndex = 0;
        cmbWeapon.SelectedIndex = 0;
        cmbRace.SelectedIndex = 0;
        cmbSex.SelectedIndex = 0;
        cmbHeadgear.SelectedIndex = 0;
        cmbChest.SelectedIndex = 0;
        cmbGloves.SelectedIndex = 0;
        cmbLegs.SelectedIndex = 0;
        settingAllCmb = false;
        CalcStatsField();

        //StatsField
        //prgHealth.Value = 80;
        //prgMagicka.Value = 80;
        //prgStamina.Value = 80;
        //txtblDefense.Text = "0";
        //txtblDamage.Text = "0";
        //txtblAtkSpeed.Text = AttackSpeed.MEDIUM.GetStringValue();
        //txtblSkill.Text = Skill.NONE.GetStringValue();
    }

    private Character ReadCharacter()
    {
        string name = txtCharacterName.Text;
        Race race = MainController.Race.Get(cmbRace.SelectedIndex);
        Headgear headgear = MainController.Headgear.Get(cmbHeadgear.SelectedIndex);
        Chest chest = MainController.Chest.Get(cmbChest.SelectedIndex);
        Gloves gloves = MainController.Gloves.Get(cmbGloves.SelectedIndex);
        Legs legs = MainController.Legs.Get(cmbLegs.SelectedIndex);
        Weapon weapon = MainController.Weapon.Get(cmbWeapon.SelectedIndex);
        Consumable consumable = MainController.Consumable.Get(cmbConsumable.SelectedIndex);
        Sex sex = (Sex)cmbSex.SelectedIndex;
        Character newCharacter = new Character(name, race, headgear, chest, gloves, legs, consumable, weapon);
        return newCharacter;
    }

    private void btnLogOut_Click(object sender, RoutedEventArgs e)
    {
        MainController.User.Logout();
        new LoginWindow().Show();
        Close();
    }

    private void btnPageLeft_Click(object sender, RoutedEventArgs e)
    {
        CurrentCharaterIndex--;
        CheckPageButtons();
        LoadUiCharacter();
    }

    private void btnPageRight_Click(object sender, RoutedEventArgs e)
    {
        CurrentCharaterIndex++;
        CheckPageButtons();
        LoadUiCharacter();
    }

    private void CheckPageButtons()
    {
        if(CurrentCharaterIndex <= 0)
        {
            btnPageLeft.IsEnabled = false;
        }
        else
        {
            btnPageLeft.IsEnabled = true;
        }

        if(CurrentCharaterIndex >= MainController.Character.Count()-1) //Pay attention, index vs count
        {
            btnPageRight.IsEnabled = false;
        }
        else
        {
            btnPageRight.IsEnabled = true;
        }
    }

    private int beforeCharacter;
    private void btnNew_Click(object sender, RoutedEventArgs e)
    {
        beforeCharacter = CurrentCharaterIndex;
        CurrentCharaterIndex = MainController.Character.Count();
        SetEnabledElements();
        LoadUiDefaultCharacter();
    }

    private void btnEdit_Click(object sender, RoutedEventArgs e)
    {
        if(CurrentCharaterIndex != 1)
        {
            SetEnabledElements();
            beforeCharacter = CurrentCharaterIndex;
        }
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        if (CurrentCharaterIndex != -1) 
        {
            MainController.Character.Delete(CurrentCharaterIndex);
            CurrentCharaterIndex--;
            CheckAmountCharacter();
            LoadUiCharacter();
        }
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        SetDisabledElements();
        CurrentCharaterIndex = beforeCharacter;
        LoadUiCharacter();
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (CurrentCharaterIndex == MainController.Character.Count())
            {
                MainController.Character.Add(ReadCharacter());
                txtCharacterCreationDate.Text = MainController.Character.Get(CurrentCharaterIndex).TimeStamp.ToString(DataHandler.Format);
            }
            else
            {
                Character editCharacter = ReadCharacter();
                editCharacter.Id = MainController.Character.Get(CurrentCharaterIndex).Id;
                MainController.Character.Update(editCharacter);
            }
            SetDisabledElements();
            CheckAmountCharacter();
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

    private void CalcStatsField()
    {
        if (!settingAllCmb)
        {
            prgHealth.Value = MainController.Race.Get(cmbRace.SelectedIndex).Health;
            prgMagicka.Value = MainController.Race.Get(cmbRace.SelectedIndex).Magicka;
            prgStamina.Value = MainController.Race.Get(cmbRace.SelectedIndex).Stamina;
            txtblSkill.Text = MainController.Race.Get(cmbRace.SelectedIndex).Skill.GetStringValue();
            txtblDamage.Text = MainController.Weapon.Get(cmbWeapon.SelectedIndex).DamagePerHit.ToString();
            txtblAtkSpeed.Text = MainController.Weapon.Get(cmbWeapon.SelectedIndex).AttackSpeed.GetStringValue();

            int defense = 0;
            defense += MainController.Headgear.Get(cmbHeadgear.SelectedIndex).Defense;
            defense += MainController.Chest.Get(cmbChest.SelectedIndex).Defense;
            defense += MainController.Gloves.Get(cmbGloves.SelectedIndex).Defense;
            defense += MainController.Legs.Get(cmbLegs.SelectedIndex).Defense;
            txtblDefense.Text = defense.ToString();
        }

    }

    private void cmbConsumable_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbConsumable.SelectedIndex >= 0)
        {
            txtblConsumable.Visibility = Visibility.Hidden;
            imgConsumable.Source = MainController.Consumable.Get(cmbConsumable.SelectedIndex).Image;
        }
    }

    private void cmbWeapon_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbWeapon.SelectedIndex >= 0)
        {
            txtblWeapon.Visibility = Visibility.Hidden;
            imgWeapon.Source = MainController.Weapon.Get(cmbWeapon.SelectedIndex).Image;
            CalcStatsField();
        }
    }

    private void cmbHeadgear_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbHeadgear.SelectedIndex >= 0)
        {
            txtblHeadgear.Visibility = Visibility.Hidden;
            brdHeadwear.Visibility = Visibility.Visible;
            imgHeadwear.Source = MainController.Headgear.Get(cmbHeadgear.SelectedIndex).Image;
            CalcStatsField();
        }
    }

    private void cmbChest_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbChest.SelectedIndex >= 0)
        {
            txtblChest.Visibility = Visibility.Hidden;
            brdBody.Visibility = Visibility.Visible;
            imgBody.Source = MainController.Chest.Get(cmbChest.SelectedIndex).Image;
            CalcStatsField();
        }
    }

    private void cmbGloves_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if ( cmbGloves.SelectedIndex >= 0)
        {
            txtblGloves.Visibility = Visibility.Hidden;
            brdGloves.Visibility = Visibility.Visible;
            imgGloves.Source = MainController.Gloves.Get(cmbGloves.SelectedIndex).Image;
            CalcStatsField();
        }
    }

    private void cmbLegs_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbLegs.SelectedIndex >= 0)
        {
            //txtblLegs.Visibility = Visibility.Hidden;
            brdShoes.Visibility = Visibility.Visible;
            imgShoes.Source = MainController.Legs.Get(cmbLegs.SelectedIndex).Image;
            CalcStatsField();
        }
    }

    private void cmbRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbRace.SelectedIndex >= 0)
        {
            txtblRace.Visibility = Visibility.Hidden;
            imgCharacter.Source = MainController.Race.Get(cmbRace.SelectedIndex).GetImage((Sex)cmbSex.SelectedIndex);
            CalcStatsField();
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

        lblUsername.IsEnabled = false;

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

        lblUsername.IsEnabled = true;

        brdHeadwear.Visibility = Visibility.Hidden;
        brdBody.Visibility = Visibility.Hidden;
        brdGloves.Visibility = Visibility.Hidden;
        brdShoes.Visibility = Visibility.Hidden;

        btnPageLeft.Visibility = Visibility.Visible;
        btnPageRight.Visibility = Visibility.Visible;

        btnNew.Visibility = Visibility.Visible;
        btnEdit.Visibility = Visibility.Visible;
        btnDelete.Visibility = Visibility.Visible;

        btnCancel.Visibility = Visibility.Hidden;
        btnSave.Visibility = Visibility.Hidden;

        CheckPageButtons();
    }

    private void lblUsername_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        UserSettingsWindow objUserSettingsWindow = new UserSettingsWindow();
        if (!(bool)objUserSettingsWindow.ShowDialog())
        {
            new RegisterWindow().Show();
            Close();
        }
    }
}