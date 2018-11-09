using Accounting.Model.Model.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Model.Abstract
{
    public interface ITransactionRepository
    {
        #region Transaction Summary
        int SaveTransactionSummary(TransactionSummary transactionSummary);
        void SaveTransactionDetail(List<TransactionAccountDetail> transactionAccountDetails, int transactionSummaryId);
        #endregion
    }
}
