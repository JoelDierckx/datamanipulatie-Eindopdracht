using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal
{
    public interface IPuzzleRepository
    {
        public IEnumerable<Puzzle> OphalenPuzzles();

        public IEnumerable<Puzzle> OphalenPuzzlesViaOnvoltooid(int accountid);

        public IEnumerable<Puzzle> OphalenPuzzlesViaNaamPuzzleassetPicarats(string naam, int puzzleassetid, int picarats);

        public IEnumerable<Puzzle> OphalenPuzzlesViaGivesPuzzles(int characterid);

        public IEnumerable<Puzzle> OphalenPuzzlesViaSolvesPuzzles(int characterid);

        public IEnumerable<Puzzle> OphalenPuzzlesViaIsPuzzleAsset();

        public Puzzle OphalenPuzzleViaID(int id);

        public bool DeletePuzzle(Puzzle puzzle);

        public bool InsertPuzzle(Puzzle puzzle);

        public bool UpdatePuzzle(Puzzle puzzle);
    }
}