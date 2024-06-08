using dal;
using models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Interaction logic for crudPuzzles.xaml
    /// </summary>
    public partial class crudPuzzles : UserControl

    {
        // var
        public Puzzle geselecteerdpuzzle;

        //link naar main ; niet invullen
        public MainWindow hoofdscherm;

        //repo's
        private IPuzzleRepository puzzleRepository = new PuzzleRepository();

        private ICharacterRepository characterRepository = new CharacterRepository();

        //--------------------------------------------
        public crudPuzzles()
        {
            InitializeComponent();
            setDatagridLayout("");
            UpdateFields();
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
            List<string> puzzlecol = new List<string>() { "name", "given by", "solved by", "puzzle asset", "picarats", "first game appearance", "made by" };
            //columnbindings
            List<string> charcolB = new List<string>() { "articleSubjectID.tittle", "Hometown", "Gender", "Occupation", "EssentialToString", "articleSubjectID.firstGameAppearance.tittle" };
            List<string> puzzlecolB = new List<string>() { "ArticleSubjectId.tittle", "GivenById.articleSubjectID.tittle", "SolvedById.articleSubjectID.tittle", "PuzzleAssetTostring", "picarats", "ArticleSubjectId.firstGameAppearance.tittle", "MadeByID.name" };

            //remove: foreach kan niet direct van zijn eigen lijst verwijderen zonder fouten
            List<DataGridColumn> list = new List<DataGridColumn>();
            foreach (var col in dataPuzzles.Columns)
            {
                list.Add(col);
            }

            foreach (var column in list)
            {
                dataPuzzles.Columns.Remove(column);
            }

            //aanmaken kolommen
            switch (layout)
            {
                //char
                case "char":
                    for (int i = 0; i < charcol.Count; i++)
                    {
                        DataGridTextColumn column = new DataGridTextColumn();
                        Binding binding = new Binding(charcolB[i]);
                        column.Binding = binding;
                        column.Header = charcol[i];
                        dataPuzzles.Columns.Add(column);
                    }
                    break;

                //puzzle
                default:
                    for (int i = 0; i < puzzlecol.Count; i++)
                    {
                        DataGridTextColumn column = new DataGridTextColumn();
                        Binding binding = new Binding(puzzlecolB[i]);
                        column.Binding = binding;
                        column.Header = puzzlecol[i];
                        dataPuzzles.Columns.Add(column);
                    }
                    break;
            }
        }

        public void UpdateFields()
        {
            // aanmaken wildcard entry
            List<Puzzle> puzzleasset = new List<Puzzle>();

            Puzzle wildcard = new Puzzle();
            ArticleSubject wildcardArt = new ArticleSubject();
            wildcard.ID = -1;
            wildcardArt.tittle = "Any puzzle";
            wildcard.ArticleSubjectId = wildcardArt;
            puzzleasset.Add(wildcard);

            // append list
            puzzleasset.AddRange(puzzleRepository.OphalenPuzzlesViaIsPuzzleAsset());

            cmbasset.ItemsSource = puzzleasset;
            cmbasset.DisplayMemberPath = "ArticleSubjectId.tittle";
            cmbasset.SelectedIndex = 0;

            dataPuzzles.ItemsSource = puzzleRepository.OphalenPuzzles();
        }

        private void btncreatePuzzle_Click(object sender, RoutedEventArgs e)
        {
            hoofdscherm.puzzleedit.editpuzzle = null;
            hoofdscherm.puzzleedit.UpdateFields();
            hoofdscherm.VeranderScherm("editpuzzle");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //WIP: close app
            hoofdscherm.CloseApp();
        }

        private void btneditPuzzle_Click(object sender, RoutedEventArgs e)
        {
            if (geselecteerdpuzzle != null)
            {
                if (geselecteerdpuzzle.PuzzleAsset.ID != null)
                {
                    hoofdscherm.puzzleedit.editpuzzle = geselecteerdpuzzle;
                    hoofdscherm.puzzleedit.UpdateFields();
                    hoofdscherm.VeranderScherm("editpuzzle");
                }
                else
                {
                    MessageBox.Show("You cannot edit a puzzleasset");
                }
            }
            else
            {
                MessageBox.Show("Select a puzzle to edit");
            }
        }

        private void btndeletePuzzle_Click(object sender, RoutedEventArgs e)
        {
            if (geselecteerdpuzzle != null)
            {
                if (geselecteerdpuzzle.PuzzleAsset.ID != null)
                {
                    puzzleRepository.DeletePuzzle(geselecteerdpuzzle);
                    dataPuzzles.ItemsSource = puzzleRepository.OphalenPuzzles();
                    setDatagridLayout("");
                    dataPuzzles.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("You cannot delete a puzzleasset");
                }
            }
            else
            {
                MessageBox.Show("Select a puzzle to edit");
            }
        }

        private void btnfilter_Click(object sender, RoutedEventArgs e)
        {
            //1) ophalen puzzles als ze er zijn

            //testen veld picarats: als leeg = -1, als tekst = fout, als int = int
            int picarats;
            if (txtPicarats.Text == "")
            {
                picarats = -1;
            }
            else if (!int.TryParse(txtPicarats.Text, out int getal))
            {
                MessageBox.Show("Picarat input is invalid");
                return;
            }
            else
            {
                picarats = Convert.ToInt32(txtPicarats.Text);
            }
            Puzzle puzzelasset = cmbasset.SelectedItem as Puzzle;
            int assetid = Convert.ToInt32(puzzelasset.ID);
            List<Puzzle> puzzles = puzzleRepository.OphalenPuzzlesViaNaamPuzzleassetPicarats(txtPuzzle.Text, assetid, picarats).ToList();

            //2) window aanpassen
            dataPuzzles.ItemsSource = puzzles;
            setDatagridLayout("");
        }

        private void btnGivesPuzzle_Click(object sender, RoutedEventArgs e)
        {
            //puzzle geselecteerd?
            if (geselecteerdpuzzle is Puzzle puzzle)
            {
                //get asset id
                int assetid;
                if (puzzle.PuzzleAsset.ID != null)
                {
                    assetid = Convert.ToInt32(puzzle.PuzzleAsset.ID);
                }
                else
                {
                    assetid = Convert.ToInt32(puzzle.ID);
                }

                //1) ophalen characters als ze er zijn
                List<Character> characters = characterRepository.OphalenCharactersViaGivesPuzzleAsset(assetid).ToList();

                //2) window aanpassen
                dataPuzzles.ItemsSource = characters;
                setDatagridLayout("char");
            }
            else
            {
                MessageBox.Show("Select a Puzzle");
            }
        }

        private void btnSolvesPuzzle_Click(object sender, RoutedEventArgs e)
        {
            if (geselecteerdpuzzle is Puzzle puzzle)
            {
                //get asset id
                int assetid;
                if (puzzle.PuzzleAsset.ID != null)
                {
                    assetid = Convert.ToInt32(puzzle.PuzzleAsset.ID);
                }
                else
                {
                    assetid = Convert.ToInt32(puzzle.ID);
                }

                //1) ophalen characters als ze er zijn
                List<Character> characters = characterRepository.OphalenCharactersViaSolvesPuzzleAsset(assetid).ToList();

                //2) window aanpassen
                dataPuzzles.ItemsSource = characters;
                setDatagridLayout("char");
            }
            else
            {
                MessageBox.Show("Select a Puzzle");
            }
        }

        private void dataPuzzles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataPuzzles.SelectedItem is Puzzle puzzle)
            {
                geselecteerdpuzzle = puzzle;
            }
        }
    }
}