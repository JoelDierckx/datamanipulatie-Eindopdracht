using System;
using System.Collections.Generic;
using System.Text;
using models;

namespace dal
{
    public interface ICharacterRepository
    {
        public IEnumerable<Character> OphalenCharactersViaGivesPuzzleAsset(int puzzleassetid);

        public IEnumerable<Character> OphalenCharactersViaSolvesPuzzleAsset(int puzzleassetid);

        public IEnumerable<Character> OphalenCharacters();

        public IEnumerable<Character> OphalenCharactersViaNaamHometownOccupation(string naam, string hometown, string occupation);

        public IEnumerable<Character> OphalenCharactersViaRelaties(int oorspronkelijkcharacterid);

        public IEnumerable<Character> OphalenCharacterViaID(int characterid);

        public bool InsertCharacter(Character character);

        public bool UpdateCharacter(Character character);

        public bool DeleteCharacter(Character characterid);
    }
}