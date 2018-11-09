using Accounting.Model.Abstract;
using Accounting.Model.Concrete;
using Accounting.Model.Model.Transaction;
using Accounting.UI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Accounting.UI.Controllers
{
    public class TransactionController : Controller
    {
        private ITransactionRepository transactionRepository;

        public TransactionController(ITransactionRepository repo)
        {
            transactionRepository = repo;
        }
        public ViewResult Create()
        {
            SetMetaDataForForm();
            return View("Edit", new CreateTransactionViewModel { TransactionAccounts = new List<TransactionAccountDetail> { new TransactionAccountDetail { } } });
        }
        public ViewResult Edit(int transactionSummaryId)
        {
            SetMetaDataForForm();
            return View(new CreateTransactionViewModel { TransactionAccounts = new List<TransactionAccountDetail> { new TransactionAccountDetail { } } });
        }
        [HttpPost]
        public ActionResult Edit(CreateTransactionViewModel transactionDetail)
        {
            if(Request.Form["Add"] != null)
            {
                transactionDetail.TransactionAccounts.Add(GetPendingTransactionAccountDetail(transactionDetail));
            }
            else if (ValidateTransaction(transactionDetail) && ModelState.IsValid)
            {
                var id = transactionRepository.SaveTransactionSummary(new TransactionSummary { TransactionDate = transactionDetail.TransactionDate, TransactionNarration = transactionDetail.TransactionNarration, TransactionSummaryId = transactionDetail.TransactionSummaryId });
                transactionRepository.SaveTransactionDetail(transactionDetail.TransactionAccounts, id);
                // ledgerRepository.SaveLedgerAccount(ledgerAccount);
                TempData["message"] = string.Format("Transaction saved successfully [{0}]", id);
                // CacheRepository.RefreshLedgerAccounts();
                return RedirectToAction("Create");
            }
            SetMetaDataForForm();
            return View(transactionDetail);
        }
        private void SetMetaDataForForm()
        {
            ViewBag.LedgerAccounts = CacheRepository.LedgerAccounts;
        }
        private bool ValidateTransaction(CreateTransactionViewModel transactionDetail)
        {
            return GetBalance(transactionDetail) == 0;
        }
        private TransactionAccountDetail GetPendingTransactionAccountDetail(CreateTransactionViewModel transactionDetail)
        {
            var balance = GetBalance(transactionDetail);
            return new TransactionAccountDetail
            {
                TransactionSide = balance > 0 ? TransactionSide.Debit : TransactionSide.Credit,
                Amount = balance * (balance < 0 ? -1 : 1)
            };
        }
        private double GetBalance(CreateTransactionViewModel transactionDetail)
        {
            return transactionDetail.TransactionAccounts.Sum(x => x.Amount * (x.TransactionSide == TransactionSide.Credit ? 1 : -1));
        }
    }
}