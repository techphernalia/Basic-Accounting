using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Accounting.Model.Model.Transaction
{
    public class TransactionAccountDetail
    {
        [HiddenInput(DisplayValue = false)]
        public int TransactionAccountDetailId { get; set; }

        [Required(ErrorMessage = "Ledger Account Mandatory")]
        [Display(Name = "Ledger Account")]
        public int LedgerAccountId { get; set; }

        [Required(ErrorMessage = "Credit/Debit Required")]
        [Display(Name = "Credit/Debit")]
        public TransactionSide TransactionSide { get; set; }

        [Required(ErrorMessage = "Amount is mandatory")]
        [Display(Name = "Amount")]
        public double Amount { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int TransactionSummaryId { get; set; }
    }
}
