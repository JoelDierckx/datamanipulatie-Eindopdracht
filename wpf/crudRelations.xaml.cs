using dal;
using models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
    /// Interaction logic for crudRelations.xaml
    /// </summary>
    public partial class crudRelations : UserControl
    {
        // var
        //link naar main ; niet invullen
        public MainWindow hoofdscherm;

        //default afbeelding pad voor display; toont als leeg
        private string defaultImgPath = "https://www.joel-entertainment.be/afbeeldingen/ui/default.png";

        //repo's
        private IRelationRepository relationRepository = new Relationrepository();

        private ICharacterRepository characterRepository = new CharacterRepository();

        private IRelationtypeRepository relationtypeRepository = new RelationtypeRepository();

        //--------------------------------------------
        public crudRelations()
        {
            InitializeComponent();
            setDatagridLayout();
            UpdateFields();
        }

        //aanpassen datagrid layout aan input
        public void setDatagridLayout()
        {
            //https://stackoverflow.com/questions/15655271/dynamically-add-columns-to-datagrid-in-wpf
            //https://stackoverflow.com/questions/75123/remove-columns-from-datatable-in-c-sharp
            //https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-create-a-binding-in-code?view=netframeworkdesktop-4.8

            //variabelen
            //columnnames
            List<string> relacol = new List<string>() { "Relation description" };
            //columnbindings
            List<string> relacolB = new List<string>() { "RelationToString" };

            //remove: foreach kan niet direct van zijn eigen lijst verwijderen zonder fouten
            List<DataGridColumn> list = new List<DataGridColumn>();
            foreach (var col in dataRelations.Columns)
            {
                list.Add(col);
            }

            foreach (var column in list)
            {
                dataRelations.Columns.Remove(column);
            }
            //aanmaken kolommen
            for (int i = 0; i < relacol.Count; i++)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                Binding binding = new Binding(relacolB[i]);
                column.Binding = binding;
                column.Header = relacol[i];
                dataRelations.Columns.Add(column);
            }
        }

        private void dataRelations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selection is relation = display
            if (dataRelations.SelectedItem is Relation relation)
            {
                foreach (Character item in cmbChar1.ItemsSource)
                {
                    if (item.ID == relation.character1.ID)
                    {
                        cmbChar1.SelectedItem = item;
                    }
                }
                foreach (Character item in cmbChar2.ItemsSource)
                {
                    if (item.ID == relation.character2.ID)
                    {
                        cmbChar2.SelectedItem = item;
                    }
                }
                foreach (Relationtype item in cmbrela.ItemsSource)
                {
                    if (item.ID == relation.Relationtype.ID)
                    {
                        cmbrela.SelectedItem = item;
                    }
                }
            }
        }

        public void UpdateFields()
        {
            // aanmaken wildcard entry
            List<Character> characters1 = new List<Character>();
            List<Character> characters2 = new List<Character>();
            List<Relationtype> relationstypes = new List<Relationtype>();
            Character wildcard = new Character();
            ArticleSubject wildcardArt = new ArticleSubject();
            Relationtype wildcardrela = new Relationtype();
            wildcardArt.tittle = "Any character";
            wildcard.articleSubjectID = wildcardArt;
            wildcardrela.name = "Any relationtype";
            characters1.Add(wildcard);
            characters2.Add(wildcard);
            relationstypes.Add(wildcardrela);

            // append list
            characters1.AddRange(characterRepository.OphalenCharacters());
            characters2.AddRange(characterRepository.OphalenCharacters());
            relationstypes.AddRange(relationtypeRepository.OphalenRelationTypes());

            cmbChar1.ItemsSource = characters1;
            cmbChar1.DisplayMemberPath = "articleSubjectID.tittle";
            cmbChar1.SelectedIndex = 0;

            cmbChar2.ItemsSource = characters2;
            cmbChar2.DisplayMemberPath = "articleSubjectID.tittle";
            cmbChar2.SelectedIndex = 0;

            cmbrela.ItemsSource = relationstypes;
            cmbrela.DisplayMemberPath = "name";
            cmbrela.SelectedIndex = 0;

            dataRelations.ItemsSource = relationRepository.OphalenRelations();
        }

        private void cmbChar1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbChar1.SelectedItem is Character character)
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

                    imgChar1.Source = bitmap;
                }
                else
                {
                    // image heeft default img nodig voor "lege display"
                    // https://stackoverflow.com/questions/18543235/how-to-set-a-default-source-for-an-image-if-binding-source-is-null

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(defaultImgPath, UriKind.Absolute);
                    bitmap.EndInit();

                    imgChar1.Source = bitmap; ;
                }
            }
        }

        private void cmbChar2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbChar2.SelectedItem is Character character)
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

                    imgChar2.Source = bitmap;
                }
                else
                {
                    // image heeft default img nodig voor "lege display"
                    // https://stackoverflow.com/questions/18543235/how-to-set-a-default-source-for-an-image-if-binding-source-is-null

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(defaultImgPath, UriKind.Absolute);
                    bitmap.EndInit();

                    imgChar2.Source = bitmap; ;
                }
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            int char1, char2, rela;
            //pass -1 als veld op "any" staat
            if (cmbChar1.SelectedIndex == 0)
            {
                char1 = -1;
            }
            else
            {
                Character character1 = cmbChar1.SelectedItem as Character;
                char1 = Convert.ToInt32(character1.ID);
            }
            if (cmbChar2.SelectedIndex == 0)
            {
                char2 = -1;
            }
            else
            {
                Character character2 = cmbChar2.SelectedItem as Character;
                char2 = Convert.ToInt32(character2.ID);
            }
            if (cmbrela.SelectedIndex == 0)
            {
                rela = -1;
            }
            else
            {
                Relationtype relationtype = cmbrela.SelectedItem as Relationtype;
                rela = Convert.ToInt32(relationtype.ID);
            }

            dataRelations.ItemsSource = relationRepository.OphalenRelationViaCharacter1en2RelationType(char1, char2, rela);
        }

        private void btnAddRelation_Click(object sender, RoutedEventArgs e)
        {
            //vul objecten in met velden
            //combobox naam terug krijgen
            //http://www.java2s.com/Tutorial/CSharp/0470__Windows-Presentation-Foundation/GetsthecurrentlyselectedComboBoxItemwhentheuserclickstheButton.htm
            Relation relation = new Relation();
            Character character1 = cmbChar1.SelectedItem as Character;
            Character character2 = cmbChar2.SelectedItem as Character;
            Relationtype relationtype = cmbrela.SelectedItem as Relationtype;

            relation.character1 = character1;
            relation.character2 = character2;
            relation.Relationtype = relationtype;

            //test of objecten geldig zijn
            if (!relation.IsGeldig())
            {
                MessageBox.Show(relation.Error);
                //reset item door ophalen uit db
                int selection = dataRelations.SelectedIndex;
                dataRelations.ItemsSource = relationRepository.OphalenRelations();
                dataRelations.SelectedIndex = selection;
                return;
            }
            else
            {
                //maak aan
                relationRepository.InsertRelation(relation);
                dataRelations.ItemsSource = relationRepository.OphalenRelations();
            }
        }

        private void btnEditRelation_Click(object sender, RoutedEventArgs e)
        {
            //vul objecten in met velden
            //combobox naam terug krijgen
            //http://www.java2s.com/Tutorial/CSharp/0470__Windows-Presentation-Foundation/GetsthecurrentlyselectedComboBoxItemwhentheuserclickstheButton.htm
            if (dataRelations.SelectedItem is Relation relation)
            {
                Character character1 = cmbChar1.SelectedItem as Character;
                Character character2 = cmbChar2.SelectedItem as Character;
                Relationtype relationtype = cmbrela.SelectedItem as Relationtype;

                relation.character1 = character1;
                relation.character2 = character2;
                relation.Relationtype = relationtype;
            }
            else
            {
                MessageBox.Show("Select a relation");
                return;
            }

            //test of objecten geldig zijn
            if (!relation.IsGeldig())
            {
                MessageBox.Show(relation.Error);
                //reset item door ophalen uit db
                int selection = dataRelations.SelectedIndex;
                dataRelations.ItemsSource = relationRepository.OphalenRelations();
                dataRelations.SelectedIndex = selection;
                return;
            }
            else
            {
                //maak aan
                relationRepository.UpdateRelation(relation);
                dataRelations.ItemsSource = relationRepository.OphalenRelations();
            }
        }

        private void btnDeleteRelation_Click(object sender, RoutedEventArgs e)
        {
            if (dataRelations.SelectedItem is Relation relation)
            {
                relationRepository.DeleteRelation(relation);
                dataRelations.ItemsSource = relationRepository.OphalenRelations();
            }
            else
            {
                MessageBox.Show("Select a relation");
                return;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //WIP: close app
            hoofdscherm.CloseApp();
        }
    }
}