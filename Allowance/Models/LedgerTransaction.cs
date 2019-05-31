using System;
using System.ComponentModel.DataAnnotations;

namespace Allowance.Models
{
    public class LedgerTransaction
    {
        public int TransactionId { get; set; }
        public string TransactionHash { get; set; }
        public int PersonId { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-mm-dd}")]
        public DateTime TDate { get; set; }
        public decimal TAmount { get; set; }
        public string TDescription { get; set; } 
    }
}
