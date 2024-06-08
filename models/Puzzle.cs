using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace models
{
    public class Puzzle : BasisKlasse
    {
        //prop
        public int? ID { get; set; }

        public Puzzle PuzzleAsset { get; set; }
        public ArticleSubject ArticleSubjectId { get; set; }
        public string InputType { get; set; }
        public string PuzzleText { get; set; }
        public string SolutionOptions { get; set; }
        public string Solution { get; set; }
        public string SolutionText { get; set; }
        public int? picarats { get; set; }
        public Character GivenById { get; set; }
        public Character SolvedById { get; set; }
        public Account MadeByID { get; set; }

        public string PuzzleAssetTostring
        {
            get
            {
                if (PuzzleAsset.ID == null)
                {
                    return "original";
                }
                else
                {
                    return PuzzleAsset.ArticleSubjectId.tittle;
                }
            }
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(PuzzleAsset) && PuzzleAsset == null)
                {
                    if (string.IsNullOrWhiteSpace(InputType))
                    {
                        return "Either the Puzzleasset is missing or the puzzledata is invalid";
                    }
                }
                else if (columnName == nameof(ArticleSubjectId) && ArticleSubjectId == null)
                {
                    return "Articlesubject is missing";
                }
                else if (columnName == nameof(picarats) && picarats <= 0)
                {
                    return "Picarats must be higher then 0";
                }
                else if (columnName == nameof(GivenById) && GivenById == null)
                {
                    return "Select a character that gives the puzzle";
                }
                else if (columnName == nameof(GivenById) && SolvedById == null)
                {
                    return "Select a character that solves the puzzle";
                }
                else if (columnName == nameof(MadeByID) && MadeByID == null)
                {
                    return "Your current account is invalid";
                }
                return "";
            }
        }
    }
}