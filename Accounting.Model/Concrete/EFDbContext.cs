using Accounting.Model.Model.Ledger;
using Accounting.Model.Model.Transaction;
using System.Data.Entity;

namespace Accounting.Model.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<LedgerType> LedgerTypes { get; set; }
        public DbSet<LedgerHead> LedgerHeads { get; set; }
        public DbSet<LedgerAccount> LedgerAccounts { get; set; }
        public DbSet<TransactionAccountDetail> TransactionAccountDetails { get; set; }
        public DbSet<TransactionSummary> TransactionSummaries { get; set; }
    }
}