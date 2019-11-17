using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Uppg_01.Models.ViewModels
{
    public class WithdrawalViewModel
    {
        [Required]
        public int WithdrawalAccountId { get; set; }

        [Required]
        public decimal WithdrawalAmount { get; set; }
    }
}
