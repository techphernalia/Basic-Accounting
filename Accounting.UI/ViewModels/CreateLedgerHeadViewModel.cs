using Accounting.Model.Model.Ledger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting.UI.ViewModels
{
    public class CreateLedgerHeadViewModel
    {
        public LedgerHead LedgerHead { get; set; }
        public IEnumerable<LedgerType> LedgerTypes { get; set; }
        public IEnumerable<LedgerHead> LedgerHeads { get; set; }
    }
}