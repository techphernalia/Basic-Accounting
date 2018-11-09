using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Accounting.Model.Model.Ledger
{
    public class LedgerAccount
    {

        [HiddenInput(DisplayValue = false)]
        public int LedgerAccountId { get; set; }

        [Required(ErrorMessage = "Please specify Account Name")]
        [Display(Name = "Account Name")]
        public string LedgerAccountName { get; set; }

        [Required(ErrorMessage = "Please select Ledger Head")]
        [Display(Name = "Ledger Head")]
        public int ParentLedgerHeadId { get; set; }

        [Display(Name = "Opening Balance")]
        public double OpeningBalance { get; set; }

        [Display(Name = "Affects Inventory")]
        public bool AffectsInventory { get; set; }
    }
}
