using Accounting.Model.Concrete;
using Accounting.Model.Model.Ledger;
using System;
using System.Linq;

namespace Accounting.Model.Utility
{
    public static class LedgerHelper
    {
        /// <summary>
        /// Get Parent Ledger Head for given Ledger Head
        /// </summary>
        /// <param name="ledgerHead">Ledger Head</param>
        /// <returns>Parent Ledger Head</returns>
        public static LedgerHead ParentLedgerHead(this LedgerHead ledgerHead)
        {
            return CacheRepository.LedgerHeads.Where(x => x.LedgerHeadId == ledgerHead.ParentLedgerHeadId).FirstOrDefault();
        }

        /// <summary>
        /// Get Parent Ledger Type for given Ledger Head
        /// </summary>
        /// <param name="ledgerHead">Ledger Head</param>
        /// <returns>Ledger Type</returns>
        public static LedgerType ParentLedgerType(this LedgerHead ledgerHead)
        {
            return CacheRepository.LedgerTypes.Where(x => x.LedgerTypeId == ledgerHead.ParentLedgerTypeId).FirstOrDefault();
        }

        /// <summary>
        /// Get Ledger Head for given Ledger Account
        /// </summary>
        /// <param name="ledgerAccount">Ledger Account</param>
        /// <returns>Ledger Head</returns>
        public static LedgerHead ParentLedgerHead(this LedgerAccount ledgerAccount)
        {
            return CacheRepository.LedgerHeads.Where(x => x.LedgerHeadId == ledgerAccount.ParentLedgerHeadId).FirstOrDefault();
        }

        /// <summary>
        /// Get Ledger Account for given Ledger Account Id
        /// </summary>
        /// <param name="ledgerAccountId">Ledger Account Id</param>
        /// <returns>Ledger Account</returns>
        public static LedgerAccount LedgerAccount(this int ledgerAccountId)
        {
            return CacheRepository.LedgerAccounts.Where(x => x.LedgerAccountId == ledgerAccountId).FirstOrDefault();
        }

        /// <summary>
        /// Get Ledger Head for given Ledger Account Id
        /// </summary>
        /// <param name="ledgerAccountId">Ledger Account Id</param>
        /// <returns>Ledger Head</returns>
        public static LedgerHead ParentLedgerHead(this int ledgerAccountId)
        {
            return CacheRepository.LedgerHeads.Where(x => x.LedgerHeadId == (ledgerAccountId.LedgerAccount().ParentLedgerHeadId)).FirstOrDefault();
        }

        /// <summary>
        /// Get Ledger Head for given Ledger Head Id
        /// </summary>
        /// <param name="ledgerHeadId">Ledger Head Id</param>
        /// <returns>Ledger Head</returns>
        public static LedgerHead LedgerHead(this int ledgerHeadId)
        {
            return CacheRepository.LedgerHeads.Where(x => x.LedgerHeadId == ledgerHeadId).FirstOrDefault();
        }

        /// <summary>
        /// Convert yyyy-MM-dd formatted Date to MMM dd, yyyy formatted Date
        /// </summary>
        /// <param name="date">Date in yyyy-MM-dd format</param>
        /// <returns>Date in MMM dd, yyyy format</returns>
        public static string ToDisplayDate(this string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd", null).ToString("MMM dd, yyyy");
        }
    }
}
