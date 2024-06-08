using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace models
{
    public class ArticleSubject : BasisKlasse
    {
        //prop
        public int? Id { get; set; }

        public string tittle { get; set; }
        public Media logo { get; set; }
        public Game firstGameAppearance { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(tittle) && string.IsNullOrWhiteSpace(tittle))
                {
                    return "Please enter a name";
                }
                else if (columnName == nameof(logo) && logo == null)
                {
                    return "Please select a valid media-item";
                }
                else if (columnName == nameof(firstGameAppearance) && firstGameAppearance == null)
                {
                    return "Please select a valid Game-item";
                }
                return "";
            }
        }
    }
}