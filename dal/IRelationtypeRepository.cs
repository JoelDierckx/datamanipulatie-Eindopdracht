using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal
{
    public interface IRelationtypeRepository
    {
        public IEnumerable<Relationtype> OphalenRelationTypes();
    }
}