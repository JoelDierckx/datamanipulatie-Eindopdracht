using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal
{
    public interface IRelationRepository
    {
        public IEnumerable<Relation> OphalenRelationViaCharacter1en2(int char1id, int char2id);

        public IEnumerable<Relation> OphalenRelations();

        public IEnumerable<Relation> OphalenRelationViaCharacter1en2RelationType(int char1id, int char2id, int relationid);

        public bool DeleteRelation(Relation relation);

        public bool InsertRelation(Relation relation);

        public bool UpdateRelation(Relation relation);
    }
}