using Accounting.Model.Abstract;
using Accounting.Model.Concrete;
using Accounting.Model.Model.Ledger;
using Accounting.Model.Utility;
using Accounting.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.UI.Controllers
{
    public class LedgerHeadController : Controller
    {
        private ILedgerRepository ledgerRepository;

        public LedgerHeadController(ILedgerRepository repo)
        {
            ledgerRepository = repo;
        }

        public ActionResult Index()
        {
            var temp = CacheRepository.LedgerHeads.OrderBy(x => x.LedgerHeadName).ToList();
            ViewBag.LedgerTypes = temp;
            return View(temp);
        }

        public ViewResult Create()
        {
            SetMetaDataForForm();
            return View("Edit", new LedgerHead());
        }

        public ViewResult Edit(int ledgerHeadId)
        {
            SetMetaDataForForm();
            return View(CacheRepository.LedgerHeads.FirstOrDefault(x => x.LedgerHeadId == ledgerHeadId));
        }

        [HttpPost]
        public ActionResult Edit(LedgerHead ledgerHead)
        {
            UpdateModel(ledgerHead);
            ModelState.Clear();
            TryValidateModel(ledgerHead);
            if (ModelState.IsValid)
            {
                ledgerRepository.SaveLedgerHead(ledgerHead);
                TempData["message"] = string.Format("{0} saved successfully", ledgerHead.LedgerHeadName);
                CacheRepository.RefreshLedgerHeads();
                return RedirectToAction("Index");
            }
            SetMetaDataForForm();
            return View(ledgerHead);
        }
        private void UpdateModel(LedgerHead ledgerHead)
        {
            if (ledgerHead.ParentLedgerTypeId == 0 && ledgerHead.ParentLedgerHeadId != 0)
            {
                ledgerHead.ParentLedgerTypeId = ledgerHead.ParentLedgerHead().ParentLedgerTypeId;
            }
        }
        private void SetMetaDataForForm()
        {
            ViewBag.LedgerHeads = CacheRepository.LedgerHeads.OrderBy(x => x.LedgerHeadName).ToList();
            ViewBag.LedgerTypes = CacheRepository.LedgerTypes.OrderBy(x => x.LedgerTypeName).ToList();
        }
    }
}