using dal;
using models;
using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace wpf
{
    /// <summary>
    /// Interaction logic for addAlias.xaml
    /// </summary>

    public partial class addAlias : UserControl
    {
        // var
        //link naar main ; niet invullen
        public MainWindow hoofdscherm;

        //default img
        private string defaultImgPath = "https://www.joel-entertainment.be/afbeeldingen/ui/default.png";

        //repo's
        private ICharacterRepository characterRepository = new CharacterRepository();

        private IAliasRepository aliasRepository = new AliasRepository();

        //--------------------------------------------
        public addAlias()
        {
            InitializeComponent();
            Updatevelden();
        }

        public void Updatevelden()
        {
            cmbCharacter.ItemsSource = characterRepository.OphalenCharacters();
            cmbCharacter.DisplayMemberPath = "articleSubjectID.tittle";
            cmbCharacter.SelectedIndex = 0;
            txtAlias.Text = "";
        }

        private void cmbCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCharacter.SelectedItem is Character character)
            {
                //afbeelding display
                if (character.articleSubjectID.logo != null)
                {
                    string imagestring = character.articleSubjectID.logo.Url;

                    // aanmaken afbeeldingen
                    //https://stackoverflow.com/questions/18435829/showing-image-in-wpf-using-the-url-link-from-database

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagestring, UriKind.Absolute);
                    bitmap.EndInit();

                    img.Source = bitmap;
                }
                else
                {
                    // image heeft default img nodig voor "lege display"
                    // https://stackoverflow.com/questions/18543235/how-to-set-a-default-source-for-an-image-if-binding-source-is-null

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(defaultImgPath, UriKind.Absolute);
                    bitmap.EndInit();

                    img.Source = bitmap; ;
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            hoofdscherm.VeranderScherm("crud");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //aanmaken alias
            Alias alias = new Alias();

            if ((cmbCharacter.SelectedItem is Character character))
            {
                alias.CharacterID = character.ID;
                alias.alias = txtAlias.Text;
            }
            else
            {
                MessageBox.Show("Character selection is invalid");
                return;
            }

            //validatie
            if (!alias.IsGeldig())
            {
                MessageBox.Show(alias.Error);
                return;
            }
            //insert
            aliasRepository.InsertAlias(alias);

            //keer terug naar hoofdscherm
            int currentindex = hoofdscherm.crudscherm.charwindow.dataCharacters.SelectedIndex;
            hoofdscherm.crudscherm.charwindow.dataCharacters.ItemsSource = characterRepository.OphalenCharacters();
            if (cmbCharacter.SelectedItem is Character character2)
            {
                foreach (Character item in hoofdscherm.crudscherm.charwindow.dataCharacters.ItemsSource)
                {
                    if (item.ID == character2.ID)
                    {
                        hoofdscherm.crudscherm.charwindow.dataCharacters.SelectedItem = item;
                    }
                }
                hoofdscherm.crudscherm.charwindow.dataCharacters.ItemsSource = aliasRepository.OphalenAliasViaCharacterID(Convert.ToInt32(character2.ID));
            }
            else
            {
                hoofdscherm.crudscherm.charwindow.dataCharacters.SelectedIndex = 0;
                hoofdscherm.crudscherm.charwindow.dataCharacters.ItemsSource = aliasRepository.OphalenAliasViaCharacterID(0);
            }
            hoofdscherm.crudscherm.charwindow.setDatagridLayout("alias");
            hoofdscherm.crudscherm.charwindow.dataCharacters.SelectedIndex = 0;
            hoofdscherm.VeranderScherm("crud");
        }
    }
}