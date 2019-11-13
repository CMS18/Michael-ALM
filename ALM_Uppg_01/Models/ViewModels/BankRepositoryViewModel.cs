using ALM_Uppg_01.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Uppg_01.Models.ViewModels
{
    public class BankRepositoryViewModel
    {
        public List<Customer> Customers { get; set; }
        public BankRepositoryViewModel()
        {
            Customers = BankRepository.GetCustomers();
        }
    }
}
