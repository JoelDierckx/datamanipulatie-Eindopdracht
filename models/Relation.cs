using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace models
{
    public class Relation : BasisKlasse
    {
        public int? ID { get; set; }
        public Character character1 { get; set; }
        public Character character2 { get; set; }
        public Relationtype Relationtype { get; set; }

        public string RelationToString
        {
            get { return character1.articleSubjectID.tittle + " is " + Relationtype.name + " of " + character2.articleSubjectID.tittle; }
        }

        public override string this[string columnName]
        {
            get
            {   //controle ID en essential wordt overgeslagen omdat deze voor het aanmaken van een character niet nodig zijn
                if (columnName == nameof(character1))
                {
                    if (character1 == null)
                    {
                        return "Please select a character for character one";
                    }
                    else
                    {
                        if (character1.ID == null)
                        {
                            return "Please select a character for character one";
                        }
                    }
                }
                else if (columnName == nameof(character2))
                {
                    if (character2 == null)
                    {
                        return "Please select a character for character two";
                    }
                    else
                    {
                        if (character2.ID == null)
                        {
                            return "Please select a character for character two";
                        }
                    }
                }
                else if (columnName == nameof(Relationtype))
                {
                    if (Relationtype == null)
                    {
                        return "Please select a Relationtype";
                    }
                    else
                    {
                        if (Relationtype.ID == null)
                        {
                            return "Please select a Relationtype";
                        }
                    }
                }
                return "";
            }
        }
    }
}