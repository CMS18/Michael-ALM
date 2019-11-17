using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Uppg_01.Models.ViewModels
{
    public class DepositViewModel
    {
        [Required]
        public int DepositAccountId { get; set; }

        [Required]
        public decimal DepositAmount { get; set; }
    }
}
