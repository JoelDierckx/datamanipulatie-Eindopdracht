using dal;
using Microsoft.Win32;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //attributen
        // alle pagina's aangemaakt om te refereren
        public crud crudscherm = new crud();

        public editCharacter characteredit = new editCharacter();
        public editPuzzles puzzleedit = new editPuzzles();
        public addAlias addAlias = new addAlias();

        //var voor account; beschikbaar over hele app.
        public Account account;

        private IAccountRepository accountRepository = new AccountRepository();

        //mediaplayer
        private MediaPlayer mediaplayer = new MediaPlayer();

        private int trackjustplayed;

        //tracks
        private List<string> soundtracks = new List<string>()
        {
            "https://www.joel-entertainment.be/afbeeldingen/sound/04%20About%20Town.mp3",
            "https://www.joel-entertainment.be/afbeeldingen/sound/20%20Professor%20Layton%27s%20Theme.mp3",
            "https://www.joel-entertainment.be/afbeeldingen/sound/05%20Puzzles.mp3",
            "https://www.joel-entertainment.be/afbeeldingen/sound/16%20The%20Looming%20Tower.mp3"
        };

        public MainWindow()
        {
            InitializeComponent();
            //opstarten; zet ref op andere schermen
            Startup();
            //zet account op defaultwaarden
            account = accountRepository.OphalenAccountViaRefID(1).ToList()[0];
            // zet default scherm naar
            VeranderScherm("crudinit");
            //start mediaplayer
            setMediaplayertrack("layton");
        }

        //Methoden
        //functie om scherm te veranderen naar ander scherm
        public void VeranderScherm(string schermnaam)
        {
            switch (schermnaam)
            {
                //reset voor opnieuw openen
                case "crudinit":
                    crudscherm.set_tab("tabCharacters");
                    main.Content = crudscherm;
                    break;

                case "crud":
                    main.Content = crudscherm;
                    break;

                case "editchar":
                    main.Content = characteredit;
                    break;

                case "editpuzzle":
                    main.Content = puzzleedit;
                    break;

                case "addalias":
                    main.Content = addAlias;
                    break;

                default:
                    main.Content = crudscherm;
                    break;
            }
        }

        // bij opstarten
        public void Startup()
        {
            //zet references naar dit scherm
            crudscherm.charwindow.hoofdscherm = this;
            crudscherm.puzzlewindow.hoofdscherm = this;
            crudscherm.relationwindow.hoofdscherm = this;
            characteredit.hoofdscherm = this;
            puzzleedit.hoofdscherm = this;
            addAlias.hoofdscherm = this;
            crudscherm.hoofdscherm = this;
        }

        //afsluiten
        public void CloseApp()
        {
            this.Close();
        }

        //mediaplayer
        //https://wpf-tutorial.com/audio-video/playing-audio/
        //https://stackoverflow.com/questions/2489906/after-playing-a-mediaelement-how-can-i-play-it-again
        public void setMediaplayertrack(string input)
        {
            switch (input)
            {
                case "abouttown":
                    Uri sound1 = new Uri(soundtracks[0]);
                    mediaplayer.Open(sound1);
                    trackjustplayed = 0;
                    mediaplayer.Play();
                    break;

                case "layton":
                    Uri sound2 = new Uri(soundtracks[1]);
                    mediaplayer.Open(sound2);
                    trackjustplayed = 1;
                    mediaplayer.Play();
                    break;

                case "puzzle":
                    Uri sound3 = new Uri(soundtracks[2]);
                    mediaplayer.Open(sound3);
                    trackjustplayed = 2;
                    mediaplayer.Play();
                    break;

                default:
                    Uri sound4 = new Uri(soundtracks[3]);
                    mediaplayer.Open(sound4);
                    trackjustplayed = 3;
                    mediaplayer.Play();
                    break;
            }

            mediaplayer.MediaEnded += (sender, args) =>
            {
                Random number = new Random();
                int track = number.Next(0, soundtracks.Count);
                //verhinderen dat hetzelfde nummer gespeeld wordt
                while (track == trackjustplayed)
                {
                    track = number.Next(0, soundtracks.Count);
                }
                Uri randtrack = new Uri(soundtracks[track]);
                mediaplayer.Open(randtrack);
                trackjustplayed = track;
                mediaplayer.Play();
            };
        }
    }
}