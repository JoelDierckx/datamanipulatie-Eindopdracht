using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace models
{
    public class Alias : BasisKlasse
    {
        public int? ID { get; set; }
        public int? CharacterID { get; set; }
        public string alias { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(CharacterID) && CharacterID == null)
                {
                    return "Please select a valid character";
                }
                else if (columnName == nameof(alias) && string.IsNullOrWhiteSpace(alias))
                {
                    return "Please enter an alias";
                }
                return "";
            }
        }
    }
}