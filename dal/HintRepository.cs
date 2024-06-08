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
    public class HintRepository : BaseRepository, IHintRepository
    {
        public Hint OphalenHintViaID(int id)
        {
            string sql = @"Select h.*
                           from Layton.Hint as h
                           where h.puzzleId = @ID;";
            var parameters = new { @ID = id };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.QuerySingleOrDefault<Hint>(sql, parameters);

                return invullen;
            }
        }

        public IEnumerable<Hint> OphalenHintViaPuzzle(int puzzleid)
        {
            string sql = @"Select h.*
                           from Layton.Hint as h
                           where h.puzzleId = @puzzlei;";
            var parameters = new { @puzzlei = puzzleid };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Hint>(sql, parameters);

                return invullen.ToList();
            }
        }
    }
}