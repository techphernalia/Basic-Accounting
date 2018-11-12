using Accounting.Model.Abstract;
using Accounting.Model.Model.Ledger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Model.Concrete
{
    public static class CacheRepository
    {
        private static ILedgerRepository ledgerRepository = new EFLedgerRepository();

        private static List<LedgerType> _ledgerTypes;
        private static List<LedgerHead> _ledgerHeads;
        private static List<LedgerAccount> _ledgerAccounts;

        public static List<LedgerHead> LedgerHeads
        {
            get
            {
                if(_ledgerHeads == null)
                {
                    _ledgerHeads = ledgerRepository.LedgerHeads.ToList();
                }
                return _ledgerHeads;
            }
        }

        public static void RefreshLedgers()
        {
            RefreshLedgerTypes();
            RefreshLedgerHeads();
            RefreshLedgerAccounts();
        }

        public static List<LedgerType> LedgerTypes
        {
            get
            {
                if(_ledgerTypes == null)
                {
                    _ledgerTypes = ledgerRepository.LedgerTypes.ToList();
                }
                return _ledgerTypes;
            }
        }

        public static List<LedgerAccount> LedgerAccounts
        {
            get
            {
                if (_ledgerAccounts== null)
                {
                    _ledgerAccounts = ledgerRepository.LedgerAccounts.ToList();
                }
                return _ledgerAccounts;
            }
        }

        public static List<LedgerHead> RefreshLedgerHeads()
        {
            return _ledgerHeads = ledgerRepository.LedgerHeads.ToList();
        }
        public static List<LedgerType> RefreshLedgerTypes()
        {
            return _ledgerTypes = ledgerRepository.LedgerTypes.ToList();
        }
        public static List<LedgerAccount> RefreshLedgerAccounts()
        {
            return _ledgerAccounts = ledgerRepository.LedgerAccounts.ToList();
        }
    }
}
