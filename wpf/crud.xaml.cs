using dal;
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
    /// Interaction logic for crud.xaml
    /// </summary>
    public partial class crud : UserControl
    {
        //attrib
        //link naar main ; niet invullen
        public MainWindow hoofdscherm;

        //windows ; public om aan referentie aan te kunnen
        public crudCharacters charwindow = new crudCharacters();

        public crudPuzzles puzzlewindow = new crudPuzzles();
        public crudRelations relationwindow = new crudRelations();

        public crud()
        {
            InitializeComponent();
        }

        //methods
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // tab control uit oefeningen, haalt window uit attrib
            string geselecteerdTabblad = (tabControl.SelectedItem as TabItem).Name;
            switch (geselecteerdTabblad)
            {
                case "tabCharacters":
                    charwindow.UpdateFields();
                    ContentWindow.Content = charwindow;
                    //hoofdscherm.setMediaplayertrack("layton");
                    break;

                case "tabRelations":
                    relationwindow.UpdateFields();
                    ContentWindow.Content = relationwindow;
                    //hoofdscherm.setMediaplayertrack("abouttown");
                    break;

                case "tabPuzzles":
                    puzzlewindow.UpdateFields();
                    ContentWindow.Content = puzzlewindow;
                    //hoofdscherm.setMediaplayertrack("puzzle");
                    break;

                default:
                    ContentWindow.Content = charwindow;
                    break;
            }
        }

        //extra methode om tabs van buiten het scherm te kunnen zetten
        public void set_tab(string tab)
        {
            // tab control uit oefeningen, haalt window uit attrib
            switch (tab)
            {
                case "tabCharacters":
                    ContentWindow.Content = charwindow;
                    break;

                case "tabRelations":
                    ContentWindow.Content = relationwindow;
                    break;

                case "tabPuzzles":
                    ContentWindow.Content = puzzlewindow;
                    break;

                default:
                    ContentWindow.Content = charwindow;
                    break;
            }
        }
    }
}