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
    public class AccountsController : Controller
    {
        private BankModel db = new BankModel();

        // GET: Accounts
        [Authorize]
        public ActionResult Index()
        {
            var accounts = Bank.GetAllAccounts(HttpContext.User.Identity.Name);
            return View(accounts);
        }

        public ActionResult Deposit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var account = Bank.GetAccountByAccountNumber(id.Value);
            return View(account);
        }
        [HttpPost]
        public ActionResult Deposit(FormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var amount = Convert.ToDecimal(controls["Amount"]);
            Bank.Deposit(accountNumber, amount);
            return RedirectToAction("Index");
        }

        public ActionResult Withdraw(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var account = Bank.GetAccountByAccountNumber(id.Value);
            return View(account);
        }

        [HttpPost]
        public ActionResult Withdraw(FormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var amount = Convert.ToDecimal(controls["Amount"]);
            try
            {
                Bank.Withdraw(accountNumber, amount);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Withdraw");
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)// id - account number. '?' means that it can be null for data type
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = Bank.GetAccountByAccountNumber(id.Value); 
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        [Authorize]
        public ActionResult Create()
        {
            var account = new Account
            {
                EmailAddress = HttpContext.User.Identity.Name
            };
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,AccountName,EmailAddress,Balance,TypeOfAccount,CreatedDate")] Account account)
        {
            if (ModelState.IsValid)
            {
                Bank.CreateAccount(account.AccountName, account.EmailAddress, account.TypeOfAccount, 0.0M);
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id) // get you the page with the edits
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountNumber,AccountName,EmailAddress,Balance,TypeOfAccount,CreatedDate")] Account account)
        {
            if (ModelState.IsValid)
            {
                Bank.EditAccount(account);
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
