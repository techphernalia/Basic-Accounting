using Accounting.Model.Model.Ledger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Model.Abstract
{
    public interface ILedgerRepository
    {
        #region Ledger Type
        IEnumerable<LedgerType> LedgerTypes { get; }
        void SaveLedgerType(LedgerType ledgerType);
        LedgerType DeleteLedgerType(int ledgerTypeId);
        #endregion

        #region Ledger Head
        IEnumerable<LedgerHead> LedgerHeads { get; }
        void SaveLedgerHead(LedgerHead ledgerHead);
        LedgerHead DeleteLedgerHead(int ledgerHeadId);
        #endregion

        #region Ledger Account
        IEnumerable<LedgerAccount> LedgerAccounts { get; }
        IEnumerable<LedgerAccount> GetLedgerAccountsForHead(int ledgerHeadId,bool showDirectOnly);
        int SaveLedgerAccount(LedgerAccount ledgerAccount);
        LedgerAccount DeleteLedgerAccount(int ledgerAccountId);
        #endregion
    }
}
