using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal
{
    public interface IHintRepository
    {
        public IEnumerable<Hint> OphalenHintViaPuzzle(int puzzleid);

        public Hint OphalenHintViaID(int id);
    }
}