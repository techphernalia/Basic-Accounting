using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Accounting.Model.Model.Transaction
{
    public class TransactionSummary
    {
        [HiddenInput(DisplayValue = false)]
        public int TransactionSummaryId { get; set; }

        [Required(ErrorMessage = "Please specify Transaction Date")]
        [Display(Name = "Transaction Date")]
        public string TransactionDate { get; set; }

        [Display(Name = "Narration")]
        public string TransactionNarration { get; set; }

    }
}
