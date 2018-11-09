using Accounting.Model.Concrete;
using Accounting.Model.Model.Ledger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Model.Utility
{
    public static class LedgerHelper
    {
        public static LedgerHead ParentLedgerHead(this LedgerHead ledgerHead)
        {
            return CacheRepository.LedgerHeads.Where(x => x.LedgerHeadId == ledgerHead.ParentLedgerHeadId).FirstOrDefault();
        }
        public static LedgerType ParentLedgerType(this LedgerHead ledgerHead)
        {
            return CacheRepository.LedgerTypes.Where(x => x.LedgerTypeId == ledgerHead.ParentLedgerTypeId).FirstOrDefault();
        }
        public static LedgerHead ParentLedgerHead(this LedgerAccount ledgerAccount)
        {
            return CacheRepository.LedgerHeads.Where(x => x.LedgerHeadId == ledgerAccount.ParentLedgerHeadId).FirstOrDefault();
        }
    }
}
