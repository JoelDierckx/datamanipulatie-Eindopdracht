using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class PuzzleAccount : BasisKlasse
    {
        //prop
        public int? ID { get; set; }

        public Puzzle PuzzleID { get; set; }
        public Account AccountID { get; set; }
        public int? picaratsleft { get; set; }

        //sql kent geen bool, bit of tinyint => int
        public int? solved { get; set; }

        public override string this[string columnName] => throw new NotImplementedException();
    }
}