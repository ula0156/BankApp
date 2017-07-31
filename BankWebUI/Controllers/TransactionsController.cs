using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bankApp;

namespace BankWebUI.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Transactions
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transactions = Bank.GetAllTransacationForAccount(id.Value);
            return View(transactions);
        }
    }
}
