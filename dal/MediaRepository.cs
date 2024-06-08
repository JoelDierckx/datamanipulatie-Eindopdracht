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
    public class MediaRepository : BaseRepository, IMediaRepository
    {
        public IEnumerable<Media> OphalenMediaViacharacterbool()
        {
            string sql = @"Select m.*
from Layton.Media as m
where m.CharacterBool = 1;";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Media>(sql);

                return invullen.ToList();
            }
        }
    }
}