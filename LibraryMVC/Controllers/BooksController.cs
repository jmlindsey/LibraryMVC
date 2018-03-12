using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryMVC.Models;
using Microsoft.AspNet.Identity;
using LibraryMVC.Models.ViewModels;

namespace LibraryMVC.Controllers
{
    public class BooksController : Controller
    {
        private LibraryDatabaseEntities db = new LibraryDatabaseEntities();

        // GET: Books
        public ActionResult Index(int? id)
        {
            var books = ((id == null) ? db.Books : db.Books.Where(x => x.Branch.BranchId == id)).Include(b => b.Branch);
            return View(books.ToList());
            
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        // GET: Books/Create
        public ActionResult CheckOut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            Patron patron = db.Patrons.Single(p => p.UserId == userId);
            var checkoutViewModel = new CheckoutViewModel
            {
                TimeCheckedOut = DateTime.Now,
                PatronName = patron.PatronName,
                BookTitle = book.Title,
                PatronId = patron.PatronId,
                BookId = book.BookId
            };
            return View(checkoutViewModel);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CheckOut(CheckoutViewModel cvm)
        {
            if (ModelState.IsValid)
            {

                var checkoutEvent = new CheckoutEvent
                {
                    DateTimeCheckedOut = cvm.TimeCheckedOut,
                    BookId = cvm.BookId,
                    PatronId = cvm.PatronId
                };
                var book = db.Books.Single(x => x.BookId == cvm.BookId);
                book.PatronId = cvm.PatronId;
                db.CheckoutEvents.Add(checkoutEvent);
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cvm);
        }

        public ActionResult CheckIn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            Patron patron = db.Patrons.Single(p => p.UserId == userId);
            var checkinVM = new CheckInViewModel
            {
                TimeCheckedIn = DateTime.Now,
                PatronId = patron.PatronId,
                PatronName = patron.PatronName,
                BookTitle = book.Title,
                BookId = book.BookId
            };
            return View(checkinVM);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CheckIn(CheckInViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                var patron = db.Patrons.Find(cvm.PatronId);
                var book = db.Books.Single(x => x.BookId == cvm.BookId);
                patron.Books.Add(book);
                book.PatronId = null;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PatronProfile", "Account");
            }
            return View(cvm);
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
