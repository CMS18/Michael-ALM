﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Uppg_01.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
