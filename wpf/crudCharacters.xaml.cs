using dal;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
    public partial class crudCharacters : UserControl
    {
        // var
        public Character geselecteerdchar;

        //link naar main ; niet invullen
        public MainWindow hoofdscherm;

        //default afbeelding pad voor display; toont als leeg
        private string defaultImgPath = "https://www.joel-entertainment.be/afbeeldingen/ui/default.png";

        //repo's
        private ICharacterRepository characterRepository = new CharacterRepository();

        private IAliasRepository aliasRepository = new AliasRepository();

        private IPuzzleRepository puzzleRepository = new PuzzleRepository();

        //----------------------------------------------------------------------------
        //start pagina
        public crudCharacters()
        {
            InitializeComponent();
            //laad alle characters voor start
            dataCharacters.ItemsSource = characterRepository.OphalenCharacters();
            setDatagridLayout("");
        }

        private void btncreateCharacter_Click(object sender, RoutedEventArgs e)
        {
            hoofdscherm.characteredit.editcharacter = null;
            hoofdscherm.characteredit.UpdateComboboxes();
            hoofdscherm.VeranderScherm("editchar");
        }

        //selectie verandering  datagrid; verander afbeelding en naam naar character ; zet geselecteerd character
        private void dataCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Updateimage();
        }

        public void Updateimage()
        {
            if (dataCharacters.SelectedItem is Character character)
            {
                //zet geselecteerd char
                geselecteerdchar = character;

                //naam display
                labelNaam.Text = geselecteerdchar.articleSubjectID.tittle;

                //afbeelding display
                if (geselecteerdchar.articleSubjectID.logo != null)
                {
                    string imagestring = geselecteerdchar.articleSubjectID.logo.Url;

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
            //WIP: close app
            hoofdscherm.CloseApp();
        }

        private void btnAlias_Click(object sender, RoutedEventArgs e)
        {
            //toon aliassen

            //character geselecteerd?
            if (geselecteerdchar is Character character)
            {
                //1) ophalen aliassen character als ze er zijn
                List<Alias> aliasses = aliasRepository.OphalenAliasViaCharacterID(Convert.ToInt32(character.ID)).ToList();

                //2) window aanpassen
                dataCharacters.ItemsSource = aliasses;
                setDatagridLayout("alias");
            }
            else
            {
                MessageBox.Show("Select a Character");
            }
        }

        private void btnPuzzleSolv_Click(object sender, RoutedEventArgs e)
        {
            //character geselecteerd?
            if (geselecteerdchar is Character character)
            {
                //1) ophalen puzzle als ze er zijn
                List<Puzzle> puzzles = puzzleRepository.OphalenPuzzlesViaSolvesPuzzles(Convert.ToInt32(character.ID)).ToList();

                //2) window aanpassen
                dataCharacters.ItemsSource = puzzles;
                setDatagridLayout("puzzle");
            }
            else
            {
                MessageBox.Show("Select a Character");
            }
        }

        private void btnPuzzleGiven_Click(object sender, RoutedEventArgs e)
        {
            //character geselecteerd?
            if (geselecteerdchar is Character character)
            {
                //1) ophalen puzzle als ze er zijn
                List<Puzzle> puzzles = puzzleRepository.OphalenPuzzlesViaGivesPuzzles(Convert.ToInt32(character.ID)).ToList();

                //2) window aanpassen
                dataCharacters.ItemsSource = puzzles;
                setDatagridLayout("puzzle");
            }
            else
            {
                MessageBox.Show("Select a Character");
            }
        }

        private void btnRelated_Click(object sender, RoutedEventArgs e)
        {
            //character geselecteerd?
            if (geselecteerdchar is Character character)
            {
                //1) ophalen characters als ze er zijn
                List<Character> charact = characterRepository.OphalenCharactersViaRelaties(Convert.ToInt32(character.ID)).ToList();

                //2) window aanpassen
                dataCharacters.ItemsSource = charact;
                setDatagridLayout("");
            }
            else
            {
                MessageBox.Show("Select a Character");
            }
        }

        private void btnfilter_Click(object sender, RoutedEventArgs e)
        {
            //1) ophalen characters als ze er zijn
            List<Character> charact = characterRepository.OphalenCharactersViaNaamHometownOccupation(txtNaam.Text, txtHome.Text, txtOccupation.Text).ToList();

            //2) window aanpassen
            dataCharacters.ItemsSource = charact;
            setDatagridLayout("");
        }

        private void btndeleteCharacter_Click(object sender, RoutedEventArgs e)
        {
            //test voor geselecteerd character
            if (dataCharacters.SelectedItem is Character character)
            {
                //mag geen essentieel character zijn
                if (character.Essential != 1)
                {
                    //delete
                    characterRepository.DeleteCharacter(character);
                    dataCharacters.ItemsSource = characterRepository.OphalenCharacters();
                    setDatagridLayout("");
                    dataCharacters.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("You cannot delete essential characters");
                }
            }
            //test voor geselecteerde alias
            else if (dataCharacters.SelectedItem is Alias alias)
            {
                //delete alias
                aliasRepository.DeleteAlias(alias);
                dataCharacters.ItemsSource = aliasRepository.OphalenAliasViaCharacterID(Convert.ToInt32(geselecteerdchar.ID));
                setDatagridLayout("alias");
                dataCharacters.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Select a Character or Alias");
            }
        }

        private void btnaddAlias_Click(object sender, RoutedEventArgs e)
        {
            //test voor geselecteerd character
            if (geselecteerdchar is Character character)
            {
                //zet var op scherm
                hoofdscherm.addAlias.Updatevelden();
                foreach (Character item in hoofdscherm.addAlias.cmbCharacter.ItemsSource)
                {
                    if (item.ID == character.ID)
                    {
                        hoofdscherm.addAlias.cmbCharacter.SelectedItem = item;
                    }
                }
                hoofdscherm.VeranderScherm("addalias");
            }
            //geen character geselecteerd
            else
            {
                hoofdscherm.addAlias.Updatevelden();
                hoofdscherm.VeranderScherm("addalias");
            }
        }

        private void btneditCharacter_Click(object sender, RoutedEventArgs e)
        {
            //test voor geselecteerd character
            if (geselecteerdchar is Character character)
            {
                //mag geen essentieel character zijn
                if (character.Essential != 1)
                {
                    //zet var op edit scherm
                    hoofdscherm.characteredit.editcharacter = character;
                    hoofdscherm.characteredit.UpdateComboboxes();
                    hoofdscherm.VeranderScherm("editchar");
                }
                else
                {
                    MessageBox.Show("You cannot edit essential characters");
                }
            }
            else
            {
                MessageBox.Show("Select a Character");
            }
        }

        //aanpassen datagrid layout aan input
        public void setDatagridLayout(string layout)
        {
            //https://stackoverflow.com/questions/15655271/dynamically-add-columns-to-datagrid-in-wpf
            //https://stackoverflow.com/questions/75123/remove-columns-from-datatable-in-c-sharp
            //https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-create-a-binding-in-code?view=netframeworkdesktop-4.8

            //variabelen
            //columnnames
            List<string> charcol = new List<string>() { "name", "hometown", "gender", "occupation", "essential", "first game appearance" };
            List<string> aliascol = new List<string>() { "alias" };
            List<string> puzzlecol = new List<string>() { "name", "given by", "solved by", "puzzle asset", "picarats" };
            //columnbindings
            List<string> charcolB = new List<string>() { "articleSubjectID.tittle", "Hometown", "Gender", "Occupation", "EssentialToString", "articleSubjectID.firstGameAppearance.tittle" };
            List<string> aliascolB = new List<string>() { "alias" };
            List<string> puzzlecolB = new List<string>() { "ArticleSubjectId.tittle", "GivenById.articleSubjectID.tittle", "SolvedById.articleSubjectID.tittle", "PuzzleAssetTostring", "picarats" };

            //remove: foreach kan niet direct van zijn eigen lijst verwijderen zonder fouten
            List<DataGridColumn> list = new List<DataGridColumn>();
            foreach (var col in dataCharacters.Columns)
            {
                list.Add(col);
            }

            foreach (var column in list)
            {
                dataCharacters.Columns.Remove(column);
            }

            //aanmaken kolommen
            switch (layout)
            {
                //puzzles
                case "puzzle":
                    for (int i = 0; i < puzzlecol.Count; i++)
                    {
                        DataGridTextColumn column = new DataGridTextColumn();
                        Binding binding = new Binding(puzzlecolB[i]);
                        column.Binding = binding;
                        column.Header = puzzlecol[i];
                        dataCharacters.Columns.Add(column);
                    }
                    break;

                //aliasses
                case "alias":
                    for (int i = 0; i < aliascol.Count; i++)
                    {
                        DataGridTextColumn column = new DataGridTextColumn();
                        Binding binding = new Binding(aliascolB[i]);
                        column.Binding = binding;
                        column.Header = aliascol[i];
                        dataCharacters.Columns.Add(column);
                    }
                    break;

                //characters
                default:
                    for (int i = 0; i < charcol.Count; i++)
                    {
                        DataGridTextColumn column = new DataGridTextColumn();
                        Binding binding = new Binding(charcolB[i]);
                        column.Binding = binding;
                        column.Header = charcol[i];
                        dataCharacters.Columns.Add(column);
                    }
                    break;
            }
        }

        public void UpdateFields()
        {
            dataCharacters.ItemsSource = characterRepository.OphalenCharacters();
            setDatagridLayout("");
            dataCharacters.SelectedIndex = 0;

            txtHome.Text = "";
            txtNaam.Text = "";
            txtOccupation.Text = "";
        }
    }
}