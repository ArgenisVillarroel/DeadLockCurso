using System;
using System.Collections.Generic;
using System.Text;

namespace AccountinManager.Data.Model
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
