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
    public class GameRepository : BaseRepository, IGameRepository
    {
        public IEnumerable<Game> OphalenGames()
        {
            string sql = @"Select g.*
from Layton.Game as g;";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Game>(sql);

                return invullen.ToList();
            }
        }
    }
}