using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Charactermapper
    {
        //dapper kan maar x aantal classen als input mapping nemen, tussenklasse puzzlemapper dient om dit te overkomen

        //character
        public int? id { get; set; }

        public string Hometown { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public int? Essential { get; set; }

        //article subject
        public int? IdA { get; set; }

        public string tittleA { get; set; }

        //media
        public int? IdM { get; set; }

        public string UrlM { get; set; }
        public string Url2M { get; set; }
        public int? CharacterBoolM { get; set; }

        //game
        public int? IdG { get; set; }

        public string tittleG { get; set; }
        public string GamecodeG { get; set; }
    }
}