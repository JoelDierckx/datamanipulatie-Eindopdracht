using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Game : BasisKlasse
    {
        //prop
        public int? Id { get; set; }

        public string tittle { get; set; }
        public string Gamecode { get; set; }

        public override string this[string columnName]
        {
            get { return ""; }
        }
    }
}