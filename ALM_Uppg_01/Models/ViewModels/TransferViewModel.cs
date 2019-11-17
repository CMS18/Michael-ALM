using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Uppg_01.Models.ViewModels
{
    public class TransferViewModel
    {

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "The account you're transferring money from")]
        public int TransferFromId { get; set; }

        [Required]
        [Display(Name = "The account you're transferring money to")]
        public int TransferToId { get; set; }


        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }
    }
}
