using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal
{
    public interface IAliasRepository
    {
        public IEnumerable<Alias> OphalenAliasViaCharacterID(int characterid);

        public bool DeleteAlias(Alias alias);

        public bool InsertAlias(Alias alias);
    }
}