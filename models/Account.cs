using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Account : BasisKlasse
    {
        public int? ID { get; set; }
        public string name { get; set; }
        public string RefId { get; set; }
        public override string this[string columnName] => throw new NotImplementedException();
    }
}