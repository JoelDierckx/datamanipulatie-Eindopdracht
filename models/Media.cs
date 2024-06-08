using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Media : BasisKlasse
    {
        //prop

        public int? Id { get; set; }
        public string Url { get; set; }
        public string Url2 { get; set; }

        //sql kent geen datatype bool, enkel bit of tinyint => int
        public int? CharacterBool { get; set; }

        public string MediaTostring
        {
            get
            {
                return "Mediaitem #" + Id;
            }
        }

        //meth

        public override string this[string columnName]
        {
            get { return ""; }
        }
    }
}