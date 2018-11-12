using Accounting.Model.Abstract;
using Accounting.Model.Model.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Model.Concrete
{
    public class EFTransactionRepository: ITransactionRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<TransactionSummary> TransactionSummaries
        {
            get
            {
                return context.TransactionSummaries;
            }
        }

        public IEnumerable<TransactionAccountDetail> TransactionAccountDetail
        {
            get
            {
                return context.TransactionAccountDetails;
            }
        }

        public int[] GetTransactionsIdsForLedgerAccount(int ledgerAccountId)
        {
            return context.TransactionAccountDetails.Where(x => x.LedgerAccountId == ledgerAccountId).Select(x => x.TransactionSummaryId).ToArray();
        }

        public List<TransactionSummary> GetTransactionSummaryForTransactionIds(IEnumerable<int> transactionIds)
        {
            return context.TransactionSummaries.Where(x => transactionIds.Contains(x.TransactionSummaryId)).ToList();
        }

        public List<TransactionAccountDetail> GetTransactionAccountDetailForTransactionIds(IEnumerable<int> transactionIds)
        {
            return context.TransactionAccountDetails.Where(x => transactionIds.Contains(x.TransactionSummaryId)).ToList();
        }

        public void SaveTransactionDetail(List<TransactionAccountDetail> transactionAccountDetails, int transactionSummaryId)
        {
            var existingDetail = context.TransactionAccountDetails.Where(x => x.TransactionSummaryId == transactionSummaryId);
            foreach(var e in existingDetail)
            {
                context.TransactionAccountDetails.Remove(e);
            }
            foreach(var t in transactionAccountDetails)
            {
                t.TransactionSummaryId = transactionSummaryId;
                t.TransactionAccountDetailId = 0;
                context.TransactionAccountDetails.Add(t);
            }
            context.SaveChanges();
        }

        public int SaveTransactionSummary(TransactionSummary transactionSummary)
        {
            if (transactionSummary.TransactionSummaryId == 0)
            {
                context.TransactionSummaries.Add(transactionSummary);
            }
            var dbEntry = context.TransactionSummaries.Find(transactionSummary.TransactionSummaryId);
            if(dbEntry != null)
            {
                dbEntry.TransactionDate = transactionSummary.TransactionDate;
                dbEntry.TransactionNarration = transactionSummary.TransactionNarration;
            }
            context.SaveChanges();
            return transactionSummary.TransactionSummaryId;
        }
    }
}
