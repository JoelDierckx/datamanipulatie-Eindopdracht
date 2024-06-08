using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal
{
    public interface IAccountRepository
    {
        public IEnumerable<Account> OphalenAccounts();

        public IEnumerable<Account> OphalenAccountViaRefID(int id);

        public IEnumerable<Account> OphalenAccountViaNaam(string naam);

        public Account OphalenAccountViaID(int id);
    }
}