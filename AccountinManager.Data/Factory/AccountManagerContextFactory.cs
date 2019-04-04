using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountinManager.Data.Factory
{
    public class AccountManagerContextFactory : IDesignTimeDbContextFactory<AccountManagerContext>
    {
        public AccountManagerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountManagerContext>();
            optionsBuilder.UseSqlServer(@"Server=.\LITHIUM; DataBase=AccountManager;Integrated Security=true");
            return new AccountManagerContext(optionsBuilder.Options);
        }
    }
}
