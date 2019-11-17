using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALM_Uppg_01.Models.Entities;
using ALM_Uppg_01.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALM_Uppg_01.Controllers
{
    public class TransferController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(TransferViewModel model = null)
        {
            if (model == null)
            {
                model = new TransferViewModel();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankRepository.Transfer(model.Amount, model.TransferFromId, model.TransferToId);
            }
           
            model.ErrorMessage = BankRepository.ErrorMessage;
            model.SuccessMessage = BankRepository.SuccessMessage;
            return View("Index", model);
        }

    }
}
