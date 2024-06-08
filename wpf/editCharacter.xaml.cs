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

namespace wpf
{
    /// <summary>
    /// Interaction logic for editCharacter.xaml
    /// </summary>
    public partial class editCharacter : UserControl
    {
        // var
        //link naar main ; niet invullen
        public MainWindow hoofdscherm;

        //als character aangepast wordt
        public Character editcharacter;

        //repo's

        private IMediaRepository mediaRepository = new MediaRepository();
        private IGameRepository gameRepository = new GameRepository();
        private ICharacterRepository characterRepository = new CharacterRepository();

        //--------------------------------------------
        public editCharacter()
        {
            InitializeComponent();
            UpdateComboboxes();
        }

        public void UpdateComboboxes()
        {
            //reset
            cmbMedia.ItemsSource = mediaRepository.OphalenMediaViacharacterbool();
            cmbMedia.DisplayMemberPath = "MediaTostring";
            cmbMedia.SelectedIndex = 0;
            cmbFirstGame.ItemsSource = gameRepository.OphalenGames();
            cmbFirstGame.DisplayMemberPath = "tittle";
            cmbFirstGame.SelectedIndex = 0;

            txtName.Text = "";
            txtOccupation.Text = "";
            txtHometown.Text = "";
            cmbGender.SelectedIndex = 0;

            // invullen voor edit
            if (editcharacter != null)
            {
                foreach (Media item in cmbMedia.ItemsSource)
                {
                    if (item.Id == editcharacter.articleSubjectID.logo.Id)
                    {
                        cmbMedia.SelectedItem = item;
                    }
                }
                cmbFirstGame.SelectedIndex = Convert.ToInt32(editcharacter.articleSubjectID.firstGameAppearance.Id) - 1;

                switch (editcharacter.Gender)
                {
                    case "female":
                        cmbGender.SelectedIndex = 1;
                        break;

                    case "male":
                        cmbGender.SelectedIndex = 0;
                        break;

                    default:
                        cmbGender.SelectedIndex = 2;
                        break;
                }
                txtName.Text = editcharacter.articleSubjectID.tittle;
                txtHometown.Text = editcharacter.Hometown;
                txtOccupation.Text = editcharacter.Occupation;
            }
        }

        private void cmbMedia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMedia.SelectedItem is Media media)
            {
                string imagestring = media.Url;

                // aanmaken afbeeldingen
                //https://stackoverflow.com/questions/18435829/showing-image-in-wpf-using-the-url-link-from-database

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagestring, UriKind.Absolute);
                bitmap.EndInit();

                img.Source = bitmap;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // character aanmaken
            if (editcharacter == null)
            {
                //vul objecten in met velden
                //combobox naam terug krijgen
                //http://www.java2s.com/Tutorial/CSharp/0470__Windows-Presentation-Foundation/GetsthecurrentlyselectedComboBoxItemwhentheuserclickstheButton.htm
                Character character = new Character();
                ArticleSubject articleSubject = new ArticleSubject();

                if ((cmbFirstGame.SelectedItem is Game game) & (cmbMedia.SelectedItem is Media media))
                {
                    articleSubject.tittle = txtName.Text;
                    articleSubject.logo = cmbMedia.SelectedItem as Media;
                    articleSubject.firstGameAppearance = cmbFirstGame.SelectedItem as Game;

                    character.articleSubjectID = articleSubject;
                    character.Hometown = txtHometown.Text;
                    character.Occupation = txtOccupation.Text;
                    ComboBoxItem comboitem = cmbGender.SelectedItem as ComboBoxItem;
                    character.Gender = comboitem.Name;
                }
                else
                {
                    MessageBox.Show("Game or Media selection is invalid");
                    return;
                }
                //test of objecten geldig zijn
                if (!articleSubject.IsGeldig() | !character.IsGeldig())
                {
                    MessageBox.Show(articleSubject.Error + character.Error);
                    return;
                }

                //maak aan
                characterRepository.InsertCharacter(character);
            }
            else
            {//character aanpassen
                if ((cmbFirstGame.SelectedItem is Game game) & (cmbMedia.SelectedItem is Media media))
                {
                    editcharacter.articleSubjectID.tittle = txtName.Text;
                    editcharacter.articleSubjectID.logo = cmbMedia.SelectedItem as Media;
                    editcharacter.articleSubjectID.firstGameAppearance = cmbFirstGame.SelectedItem as Game;

                    editcharacter.Hometown = txtHometown.Text;
                    editcharacter.Occupation = txtOccupation.Text;
                    ComboBoxItem comboitem = cmbGender.SelectedItem as ComboBoxItem;
                    editcharacter.Gender = comboitem.Name;
                }
                else
                {
                    MessageBox.Show("Game or Media selection is invalid");
                    return;
                }
                //test of objecten geldig zijn
                if (!editcharacter.articleSubjectID.IsGeldig() | !editcharacter.IsGeldig())
                {
                    MessageBox.Show(editcharacter.articleSubjectID.Error + editcharacter.Error);
                    return;
                }

                //maak aan
                characterRepository.UpdateCharacter(editcharacter);
            }
            //keer terug naar hoofdscherm
            int currentindex = hoofdscherm.crudscherm.charwindow.dataCharacters.SelectedIndex;
            hoofdscherm.crudscherm.charwindow.dataCharacters.ItemsSource = characterRepository.OphalenCharacters();
            hoofdscherm.crudscherm.charwindow.setDatagridLayout("");
            hoofdscherm.crudscherm.charwindow.dataCharacters.SelectedIndex = currentindex;
            hoofdscherm.VeranderScherm("crud");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            hoofdscherm.VeranderScherm("crud");
        }
    }
}