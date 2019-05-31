using System;
using System.ComponentModel.DataAnnotations;

namespace Allowance.Models
{
    public class LedgerTransaction
    {
        public int TransactionId { get; set; }
        public string TransactionHash { get; set; }
        public int PersonId { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TDate { get; set; }
        public decimal TAmount { get; set; }
        public decimal TBalance { get; set; } = 0;
        public string TDescription { get; set; } 
    }
}
