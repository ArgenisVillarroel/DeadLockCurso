using AccountinManager.Data;
using AccountinManager.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AccountManager.Data.Test
{
    [TestClass]
    public class AccountManagerTest
    {
        private AccountManagerContext context;
        public AccountManagerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountManagerContext>();
            optionsBuilder.UseSqlServer(@"Server=.\LITHIUM; DataBase=AccountManager;Integrated Security=true", opt=>
            {
                opt.MigrationsAssembly(typeof(AccountManagerContext).Assembly.FullName);
            });
            
            context = new AccountManagerContext(optionsBuilder.Options);
            context.Database.Migrate();
        }

        [TestMethod]
        public void AAddAccountTypeOk()
        {
            int result = 0;
            AccountType accountType = new AccountType()
            {
                Code = "PAS",
                Name = "Pasivo"
            };

            context.AccountTypes.Add(accountType);
            if (context.ChangeTracker.HasChanges())
                result = context.SaveChanges();

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void BAddAccountTypeFail()
        {
            AccountType accountType = new AccountType()
            {
                Code = "PAS",
                Name = "Pasivos"
            };

            context.AccountTypes.Add(accountType);
            if (context.ChangeTracker.HasChanges())
               context.SaveChanges();

        }

        [TestMethod]
        public void CEditAccountTypeOk()
        {
            int result = 0;
            AccountType accountType = context.AccountTypes
                .SingleOrDefault(at=>at.Code == "PAS");

            accountType.Name = "Pasivos";

            if (context.ChangeTracker.HasChanges())
                result = context.SaveChanges();

            Assert.AreEqual(result, 1);
        }


        [TestMethod]
        public void DDeleteAccountTypeOk()
        {
            int result = 0;
            AccountType accountType = context.AccountTypes
                .SingleOrDefault(at => at.Code == "PAS");

            context.Remove(accountType);

            if (context.ChangeTracker.HasChanges())
                result = context.SaveChanges();

            Assert.AreEqual(result, 1);
        }
    }
}
