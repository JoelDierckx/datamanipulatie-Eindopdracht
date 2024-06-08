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
    public class AliasRepository : BaseRepository, IAliasRepository
    {
        public IEnumerable<Alias> OphalenAliasViaCharacterID(int characterid)
        {
            string sql = @"select a.*
                        from Layton.Alias as a
                        where a.characterId = @ID;";
            var parameters = new { @ID = characterid };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Alias>(
                    sql, parameters);

                return invullen.ToList();
            }
        }

        public bool DeleteAlias(Alias alias)
        {
            string sql = @"DELETE FROM Layton.Alias
                            where id = @AL;";
            var parameters = new
            {
                @AL = alias.ID,
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var rijen = db.Execute(sql, parameters);
                if (rijen >= 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool InsertAlias(Alias alias)
        {
            //insert alias
            string sql = @"INSERT INTO Layton.Alias (characterId,alias)
                            VALUES (@ID,@AL);";

            var parameters = new
            {
                @ID = alias.CharacterID,
                @AL = alias.alias,
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var rijen = db.Execute(sql, parameters);
                if (rijen == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}