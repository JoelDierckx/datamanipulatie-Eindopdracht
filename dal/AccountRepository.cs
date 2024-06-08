using Dapper;
using models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace dal
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public IEnumerable<Account> OphalenAccounts()
        {
            string sql = @"Select * from Layton.Account";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Account>(sql).ToList();
            }
        }

        public Account OphalenAccountViaID(int id)
        {
            string sql = @"select a.*
                        from Layton.Account as a
                        where a.id = @ID;";
            var parameters = new { @ID = id };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.QuerySingleOrDefault<Account>(
                    sql, parameters);

                return invullen;
            }
        }

        public IEnumerable<Account> OphalenAccountViaNaam(string naam)
        {
            string sql = @"select a.*
                        from Layton.Account as a
                        where a.name Like '%@name%' ;";
            var parameters = new { @name = naam };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Account>(
                    sql, parameters);

                return invullen.ToList();
            }
        }

        public IEnumerable<Account> OphalenAccountViaRefID(int id)
        {
            string sql = @"select a.*
                        from Layton.Account as a
                        where a.refID = @ID;";
            var parameters = new { @ID = id };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Account>(
                    sql, parameters);

                return invullen.ToList();
            }
        }
    }
}