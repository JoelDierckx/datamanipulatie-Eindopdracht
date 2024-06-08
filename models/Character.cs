using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace models
{
    public class Character : BasisKlasse
    {
        //prop
        public int? ID { get; set; }

        public string Hometown { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }

        //sql kent geen bool, enkel bit of tinyint => int
        public int? Essential { get; set; }

        public ArticleSubject articleSubjectID { get; set; }

        public override string this[string columnName]
        {
            get
            {   //controle ID en essential wordt overgeslagen omdat deze voor het aanmaken van een character niet nodig zijn
                if (columnName == nameof(Hometown) && string.IsNullOrWhiteSpace(Hometown))
                {
                    return "Please enter a hometown";
                }
                else if (columnName == nameof(Occupation) && string.IsNullOrWhiteSpace(Occupation))
                {
                    return "Please enter an occupation";
                }
                else if (columnName == nameof(Gender) && string.IsNullOrWhiteSpace(Gender))
                {
                    return "The characters gender is missing";
                }
                else if (columnName == nameof(Gender) && !(Gender == "male" | Gender == "female" | Gender == "X"))
                {
                    return "The characters gender is not valid";
                }
                else if (columnName == nameof(articleSubjectID) && articleSubjectID == null)
                {
                    return "The characters information is invalid";
                }
                return "";
            }
        }

        public string EssentialToString
        {
            get
            {
                string output;
                if (Essential == 1)
                {
                    output = "yes";
                }
                else
                {
                    output = "no";
                }
                return output;
            }
            set { }
        }
    }
}