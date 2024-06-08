using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal
{
    public interface IGameRepository
    {
        public IEnumerable<Game> OphalenGames();
    }
}