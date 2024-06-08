using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Puzzlemapper
    {
        //dapper kan maar x aantal classen als input mapping nemen, tussenklasse puzzlemapper dient om dit te overkomen
        //ArticleSubject,
        public int? Id { get; set; }

        public string tittle { get; set; }

        //Game,
        public int? IdG { get; set; }

        public string tittleG { get; set; }
        public string GamecodeG { get; set; }

        //Media,
        public int? IdM { get; set; }

        public string UrlM { get; set; }
        public string Url2M { get; set; }
        public int? CharacterBoolM { get; set; }

        //Puzzle,
        public int? IDP { get; set; }

        public string InputTypeP { get; set; }
        public string PuzzleTextP { get; set; }
        public string SolutionOptionsP { get; set; }
        public string SolutionP { get; set; }
        public string SolutionTextP { get; set; }
        public int? picaratsP { get; set; }

        //ArticleSubject,
        public int? Id1 { get; set; }

        public string tittle1 { get; set; }

        //Game,
        public int? IdG1 { get; set; }

        public string tittleG1 { get; set; }
        public string GamecodeG1 { get; set; }

        //Media,
        public int? IdM1 { get; set; }

        public string UrlM1 { get; set; }
        public string Url2M1 { get; set; }
        public int? CharacterBoolM1 { get; set; }

        //Account,
        public int? IDA { get; set; }

        public string nameA { get; set; }
        public string RefIdA { get; set; }

        //Character,
        public int? IDC { get; set; }

        public string HometownC { get; set; }
        public string OccupationC { get; set; }
        public string GenderC { get; set; }
        public int? EssentialC { get; set; }

        //ArticleSubject,
        public int? Id2 { get; set; }

        public string tittle2 { get; set; }

        //Game,
        public int? IdG2 { get; set; }

        public string tittleG2 { get; set; }
        public string GamecodeG2 { get; set; }

        //Media,
        public int? IdM2 { get; set; }

        public string UrlM2 { get; set; }
        public string Url2M2 { get; set; }
        public int? CharacterBoolM2 { get; set; }

        //Character,
        public int? IDC2 { get; set; }

        public string HometownC2 { get; set; }
        public string OccupationC2 { get; set; }
        public string GenderC2 { get; set; }
        public int? EssentialC2 { get; set; }

        //ArticleSubject,
        public int? Id3 { get; set; }

        public string tittle3 { get; set; }

        //Game,
        public int? IdG3 { get; set; }

        public string tittleG3 { get; set; }
        public string GamecodeG3 { get; set; }

        //Media
        public int? IdM3 { get; set; }

        public string UrlM3 { get; set; }
        public string Url2M3 { get; set; }
        public int? CharacterBoolM3 { get; set; }
    }
}