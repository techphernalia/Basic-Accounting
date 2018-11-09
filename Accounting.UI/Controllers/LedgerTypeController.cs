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
    public class LedgerTypeController : Controller
    {
        private ILedgerRepository ledgerRepository;

        public LedgerTypeController(ILedgerRepository repo)
        {
            ledgerRepository = repo;
        }

        public ActionResult Index()
        {
            return View(CacheRepository.LedgerTypes);
        }

        public ViewResult Create()
        {
            return View("Edit", new LedgerType());
        }

        public ViewResult Edit(int ledgerTypeId)
        {
            return View(CacheRepository.LedgerTypes.FirstOrDefault(x => x.LedgerTypeId == ledgerTypeId));
        }

        [HttpPost]
        public ActionResult Edit(LedgerType ledgerType)
        {
            if(ModelState.IsValid)
            {
                ledgerRepository.SaveLedgerType(ledgerType);
                TempData["message"] = string.Format("{0} saved successfully", ledgerType.LedgerTypeName);
                CacheRepository.RefreshLedgerTypes();
                return RedirectToAction("Index");
            }
            return View(ledgerType);
        }
    }
}