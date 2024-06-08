using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Hint : BasisKlasse
    {
        //prop
        public int? ID { get; set; }

        public int? PuzzleId { get; set; }
        public int? HintIndex { get; set; }
        public string HintText { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(PuzzleId) && PuzzleId < 0)
                {
                    return "PuzzleID mag niet kleiner dan 0 zijn";
                }

                return "";
            }
        }
    }
}