using System;
using System.Collections.Generic;
using System.Text;

namespace AccountinManager.Data.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual AccountType AccountType { get; set; }
        public int AccountTypeId { get; set; }

    }
}
