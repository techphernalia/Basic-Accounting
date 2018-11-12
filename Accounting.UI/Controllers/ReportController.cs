using Accounting.Model.Abstract;
using Accounting.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.UI.Controllers
{
    public class ReportController:Controller
    {
        private ITransactionRepository transactionRepository;
        public ReportController(ITransactionRepository repo)
        {
            transactionRepository = repo;
        }
        public void IncomeStatement()
        {

        }

        public void BalanceSheet()
        {

        }

        public void CashFlowStatement()
        {

        }

        public ActionResult GenerateSQLScripts()
        {

            // "SET IDENTITY_INSERT LedgerTypes ON";

            var query = PrependQuery("LedgerTypes", string.Join("," + Environment.NewLine, CacheRepository.LedgerTypes.Select(x => string.Format("({0},'{1}',{2})", x.LedgerTypeId, x.LedgerTypeName, (x.CanParticipateInPnL ? 1 : 0)))));
            query += PrependQuery("LedgerHeads", string.Join("," + Environment.NewLine, CacheRepository.LedgerHeads.Select(x => string.Format("({0},'{1}','{2}',{3},{4},{5})", x.LedgerHeadId, x.LedgerHeadName,x.LedgerHeadDescription,x.ParentLedgerTypeId,x.ParentLedgerTypeId, (x.AffectsGrossPnL ? 1 : 0)))));
            query += PrependQuery("LedgerAccounts", string.Join("," + Environment.NewLine, CacheRepository.LedgerAccounts.Select(x => string.Format("({0},'{1}',{2},{3},{4})", x.LedgerAccountId, x.LedgerAccountName,x.ParentLedgerHeadId,x.OpeningBalance, (x.AffectsInventory? 1 : 0)))));

            query += PrependQuery("TransactionSummaries", string.Join("," + Environment.NewLine, transactionRepository.TransactionSummaries.Select(x => string.Format("('{0}','{1}','{2}')", x.TransactionSummaryId, x.TransactionDate, x.TransactionNarration))));
            query += PrependQuery("TransactionAccountDetails", string.Join("," + Environment.NewLine, transactionRepository.TransactionAccountDetail.Select(x => string.Format("({0},{1},{2},{3},{4})", x.TransactionAccountDetailId, x.LedgerAccountId, (int)x.TransactionSide,x.Amount,x.TransactionSummaryId))));


            return View((object)query);
        }
        private string PrependQuery(string tableName, string query)
        {
            return string.Format("SET IDENTITY_INSERT {0} ON{1}GO{1}INSERT INTO {0} VALUES{1}{2}{1}GO{1}SET IDENTITY_INSERT {0} OFF{1}GO{1}", tableName,Environment.NewLine, query);
        }
    }
}