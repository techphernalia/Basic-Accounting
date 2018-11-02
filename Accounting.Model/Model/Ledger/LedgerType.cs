using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Accounting.Model.Model.Ledger
{
    public class LedgerType
    {
        [HiddenInput(DisplayValue = false)]
        public int LedgerTypeId { get; set; }

        [Required(ErrorMessage = "Please specify Ledger Type")]
        [Display(Name = "Ledger Type")]
        public string LedgerTypeName { get; set; }

        [Display(Name = "Accounts under Ledger Type affect PnL")]
        public bool CanParticipateInPnL { get; set; }
    }
}
