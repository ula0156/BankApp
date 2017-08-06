using System.Net;
using System.Web.Mvc;
using bankApp;

namespace BankWebUI.Controllers
{
    public class TransactionsController : Controller
    {
        private BankModel db = new BankModel();

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
