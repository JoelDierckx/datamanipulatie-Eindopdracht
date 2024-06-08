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
    /// Interaction logic for editPuzzles.xaml
    /// </summary>
    public partial class editPuzzles : UserControl
    {
        // var
        //link naar main ; niet invullen
        public MainWindow hoofdscherm;

        //als puzzle aangepast wordt
        public Puzzle editpuzzle;

        //repo's
        private ICharacterRepository characterRepository = new CharacterRepository();

        private IPuzzleRepository puzzleRepository = new PuzzleRepository();

        //--------------------------------------------
        public editPuzzles()
        {
            InitializeComponent();
            UpdateFields();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            hoofdscherm.VeranderScherm("crud");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // character aanmaken
            if (editpuzzle == null)
            {
                //vul objecten in met velden
                //combobox naam terug krijgen
                //http://www.java2s.com/Tutorial/CSharp/0470__Windows-Presentation-Foundation/GetsthecurrentlyselectedComboBoxItemwhentheuserclickstheButton.htm
                Puzzle puzzle = new Puzzle();
                ArticleSubject articleSubject = new ArticleSubject();

                Puzzle puzzleasset = cmbAsset.SelectedItem as Puzzle;

                articleSubject.tittle = txtName.Text;
                articleSubject.logo = puzzleasset.ArticleSubjectId.logo;
                articleSubject.firstGameAppearance = puzzleasset.ArticleSubjectId.firstGameAppearance;

                puzzle.ArticleSubjectId = articleSubject;
                puzzle.PuzzleAsset = puzzleasset;
                puzzle.SolvedById = cmbSolved.SelectedItem as Character;
                puzzle.GivenById = cmbGiven.SelectedItem as Character;
                puzzle.MadeByID = hoofdscherm.account;
                //test veld picarats voor integer input
                if (int.TryParse(txtPicarats.Text, out int getal))
                {
                    puzzle.picarats = getal;
                }
                else
                {
                    MessageBox.Show("Enter a number for the picarats");
                    return;
                }

                //test of objecten geldig zijn
                if (!articleSubject.IsGeldig() | !puzzle.IsGeldig())
                {
                    MessageBox.Show(articleSubject.Error + puzzle.Error);
                    return;
                }

                //maak aan
                puzzleRepository.InsertPuzzle(puzzle);
            }
            else
            {//puzzle aanpassen
                Puzzle puzzleasset = cmbAsset.SelectedItem as Puzzle;

                editpuzzle.ArticleSubjectId.tittle = txtName.Text;
                editpuzzle.ArticleSubjectId.logo = puzzleasset.ArticleSubjectId.logo;
                editpuzzle.ArticleSubjectId.firstGameAppearance = puzzleasset.ArticleSubjectId.firstGameAppearance;

                editpuzzle.PuzzleAsset = puzzleasset;
                editpuzzle.SolvedById = cmbSolved.SelectedItem as Character;
                editpuzzle.GivenById = cmbGiven.SelectedItem as Character;
                editpuzzle.MadeByID = hoofdscherm.account;
                //test veld picarats voor integer input
                if (int.TryParse(txtPicarats.Text, out int getal))
                {
                    editpuzzle.picarats = getal;
                }
                else
                {
                    MessageBox.Show("Enter a number for the picarats");
                    return;
                }

                //test of objecten geldig zijn
                if (!editpuzzle.ArticleSubjectId.IsGeldig() | !editpuzzle.IsGeldig())
                {
                    MessageBox.Show(editpuzzle.ArticleSubjectId.Error + editpuzzle.Error);
                    return;
                }

                //maak aan
                puzzleRepository.UpdatePuzzle(editpuzzle);
            }
            //keer terug naar hoofdscherm
            int currentindex = hoofdscherm.crudscherm.puzzlewindow.dataPuzzles.SelectedIndex;
            hoofdscherm.crudscherm.puzzlewindow.dataPuzzles.ItemsSource = puzzleRepository.OphalenPuzzles();
            hoofdscherm.crudscherm.puzzlewindow.setDatagridLayout("");
            hoofdscherm.crudscherm.puzzlewindow.dataPuzzles.SelectedIndex = currentindex;
            hoofdscherm.VeranderScherm("crud");
        }

        public void UpdateFields()
        {
            txtName.Text = "";
            txtPicarats.Text = "";

            cmbAsset.ItemsSource = puzzleRepository.OphalenPuzzlesViaIsPuzzleAsset();
            cmbAsset.DisplayMemberPath = "ArticleSubjectId.tittle";
            cmbAsset.SelectedIndex = 0;
            cmbGiven.ItemsSource = characterRepository.OphalenCharacters();
            cmbGiven.DisplayMemberPath = "articleSubjectID.tittle";
            cmbGiven.SelectedIndex = 0;
            cmbSolved.ItemsSource = characterRepository.OphalenCharacters();
            cmbSolved.DisplayMemberPath = "articleSubjectID.tittle";
            cmbSolved.SelectedIndex = 0;

            // invullen voor edit
            if (editpuzzle != null)
            {
                foreach (Puzzle puzzle in cmbAsset.ItemsSource)
                {
                    if (editpuzzle.PuzzleAsset.ID == puzzle.ID)
                    {
                        cmbAsset.SelectedItem = puzzle;
                    }
                }
                foreach (Character item in cmbGiven.ItemsSource)
                {
                    if (editpuzzle.GivenById.ID == item.ID)
                    {
                        cmbGiven.SelectedItem = item;
                    }
                }
                foreach (Character item in cmbSolved.ItemsSource)
                {
                    if (editpuzzle.SolvedById.ID == item.ID)
                    {
                        cmbSolved.SelectedItem = item;
                    }
                }
                txtName.Text = editpuzzle.ArticleSubjectId.tittle;
                txtPicarats.Text = Convert.ToString(editpuzzle.picarats);
            }
        }
    }
}