using Accounting.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.Model.Model.Ledger;

namespace Accounting.Model.Concrete
{
    public class EFLedgerRepository : ILedgerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<LedgerAccount> LedgerAccounts
        {
            get
            {
                return context.LedgerAccounts;
            }
        }

        public IEnumerable<LedgerHead> LedgerHeads
        {
            get
            {
                return context.LedgerHeads;
            }
        }

        public IEnumerable<LedgerType> LedgerTypes
        {
            get
            {
                return context.LedgerTypes;
            }
        }

        public IEnumerable<LedgerAccount> GetLedgerAccountsForHead(int ledgerHeadId, bool showDirectOnly)
        {
            if (showDirectOnly)
            {
                return context.LedgerAccounts.Where(account => account.ParentLedgerHeadId == ledgerHeadId);
            }
            List<int> ledgerHeadIds = new List<int> { ledgerHeadId };
            for(var i=0;i<ledgerHeadIds.Count;i++)
            {
                var tempId = ledgerHeadIds[i];
                ledgerHeadIds.AddRange(context.LedgerHeads.Where(x => x.ParentLedgerHeadId == tempId).Select(x => x.LedgerHeadId).ToList());
            }
            return context.LedgerAccounts.Where(account => ledgerHeadIds.Contains(account.ParentLedgerHeadId));
        }

        public LedgerAccount DeleteLedgerAccount(int ledgerAccountId)
        {
            var dbEntry = context.LedgerAccounts.Find(ledgerAccountId);
            if (dbEntry == null)
            {
                return null;
            }
            context.LedgerAccounts.Remove(dbEntry);
            context.SaveChanges();
            return dbEntry;
        }

        public LedgerHead DeleteLedgerHead(int ledgerHeadId)
        {
            var dbEntry = context.LedgerHeads.Find(ledgerHeadId);
            if (dbEntry == null)
            {
                return null;
            }
            context.LedgerHeads.Remove(dbEntry);
            context.SaveChanges();
            return dbEntry;
        }

        public LedgerType DeleteLedgerType(int ledgerTypeId)
        {
            var dbEntry = context.LedgerTypes.Find(ledgerTypeId);
            if (dbEntry == null)
            {
                return null;
            }
            context.LedgerTypes.Remove(dbEntry);
            context.SaveChanges();
            return dbEntry;
        }

        public int SaveLedgerAccount(LedgerAccount ledgerAccount)
        {
            if (ledgerAccount.LedgerAccountId == 0)
            {
                context.LedgerAccounts.Add(ledgerAccount);
            }
            else
            {
                var dbEntry = context.LedgerAccounts.Find(ledgerAccount.LedgerAccountId);
                if (dbEntry != null)
                {
                    dbEntry.LedgerAccountName = ledgerAccount.LedgerAccountName;
                    dbEntry.ParentLedgerHeadId = ledgerAccount.ParentLedgerHeadId;
                    dbEntry.OpeningBalance = ledgerAccount.OpeningBalance;
                    dbEntry.AffectsInventory = ledgerAccount.AffectsInventory;
                }
            }
            context.SaveChanges();
            return ledgerAccount.LedgerAccountId;
        }

        public void SaveLedgerHead(LedgerHead ledgerHead)
        {
            if (ledgerHead.LedgerHeadId == 0)
            {
                context.LedgerHeads.Add(ledgerHead);
            }
            else
            {
                var dbEntry = context.LedgerHeads.Find(ledgerHead.LedgerHeadId);
                if (dbEntry != null)
                {
                    dbEntry.LedgerHeadName = ledgerHead.LedgerHeadName;
                    dbEntry.LedgerHeadDescription = ledgerHead.LedgerHeadDescription;
                    dbEntry.ParentLedgerTypeId = ledgerHead.ParentLedgerTypeId;
                    dbEntry.ParentLedgerHeadId = ledgerHead.ParentLedgerHeadId;
                    dbEntry.AffectsGrossPnL = ledgerHead.AffectsGrossPnL;
                }
            }
            context.SaveChanges();
        }

        public void SaveLedgerType(LedgerType ledgerType)
        {
            if (ledgerType.LedgerTypeId == 0)
            {
                context.LedgerTypes.Add(ledgerType);
            }
            else
            {
                var dbEntry = context.LedgerTypes.Find(ledgerType.LedgerTypeId);
                if (dbEntry != null)
                {
                    dbEntry.LedgerTypeName = ledgerType.LedgerTypeName;
                    dbEntry.CanParticipateInPnL = ledgerType.CanParticipateInPnL;
                }
            }
            context.SaveChanges();
        }
    }
}