using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Accounting.Model.Model.Ledger
{
    public class LedgerHead
    {
        [HiddenInput(DisplayValue = false)]
        public int LedgerHeadId { get; set; }

        [Required(ErrorMessage = "Please specify Ledger Head")]
        [Display(Name = "Ledger Head")]
        public string LedgerHeadName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string LedgerHeadDescription { get; set; }

        [Required(ErrorMessage = "Please select Ledger Type")]
        [Display(Name = "Ledger Type")]
        public int ParentLedgerTypeId { get; set; }

        [Required(ErrorMessage = "Please select Ledger Head")]
        [Display(Name = "Group Under")]
        public int ParentLedgerHeadId { get; set; }

        [Display(Name = "Affects Gross PnL")]
        public bool AffectsGrossPnL { get; set; }
    }
}
