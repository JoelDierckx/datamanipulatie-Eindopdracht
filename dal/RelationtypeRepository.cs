using models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;

namespace dal
{
    public class RelationtypeRepository : BaseRepository, IRelationtypeRepository
    {
        public IEnumerable<Relationtype> OphalenRelationTypes()
        {
            string sql = @"Select rt.*
from Layton.Relationtype as rt;
;";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Relationtype>(sql);

                return invullen.ToList();
            }
        }
    }
}