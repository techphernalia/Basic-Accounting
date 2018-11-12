using Accounting.Model.Abstract;
using Accounting.Model.Concrete;
using Accounting.Model.Model.Ledger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.UI.Controllers
{
    public class LedgerAccountController : Controller
    {
        private ILedgerRepository ledgerRepository;

        public LedgerAccountController(ILedgerRepository repo)
        {
            ledgerRepository = repo;
        }

        public ActionResult Index()
        {
            ViewBag.LedgerHeads = CacheRepository.LedgerHeads.OrderBy(x=>x.LedgerHeadName).ToList();
            return View(CacheRepository.LedgerAccounts.OrderBy(x=>x.LedgerAccountName));
        }
        public ViewResult Create()
        {
            SetMetaDataForForm();
            return View("Edit", new LedgerAccount());
        }
        public ViewResult Edit(int ledgerAccountId)
        {
            SetMetaDataForForm();
            return View(CacheRepository.LedgerAccounts.FirstOrDefault(x => x.LedgerAccountId == ledgerAccountId));
        }
        [HttpPost]
        public ActionResult Edit(LedgerAccount ledgerAccount)
        {
            ModelState.Clear();
            TryValidateModel(ledgerAccount);
            if (ModelState.IsValid)
            {
                ledgerRepository.SaveLedgerAccount(ledgerAccount);
                TempData["message"] = string.Format("{0} saved successfully", ledgerAccount.LedgerAccountName);
                CacheRepository.RefreshLedgerAccounts();
                return RedirectToAction("Index");
            }
            SetMetaDataForForm();
            return View(ledgerAccount);
        }
        private void SetMetaDataForForm()
        {
            ViewBag.LedgerHeads = CacheRepository.LedgerHeads.OrderBy(x=>x.LedgerHeadName).ToList();
            ViewBag.LedgerTypes = CacheRepository.LedgerTypes.OrderBy(x=>x.LedgerTypeName).ToList();
        }
    }
}