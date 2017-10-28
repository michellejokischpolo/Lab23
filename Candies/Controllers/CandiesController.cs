using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Candies.Models;

namespace Candies.Controllers
{
    public class CandiesController : Controller
    {
        private CandyEntities2 db = new CandyEntities2();

        // GET: Candies
        public ActionResult Index()
        {
            return View(db.Candies.ToList());
        }

        // GET: Candies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candy candy = db.Candies.Find(id);
            if (candy == null)
            {
                return HttpNotFound();
            }
            return View(candy);
        }

        // GET: Candies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type_of_Candy,Color_of_Candy,Number_of_Candies")] Candy candy)
        {
            if (ModelState.IsValid)
            {
                db.Candies.Add(candy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candy);
        }

        // GET: Candies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candy candy = db.Candies.Find(id);
            if (candy == null)
            {
                return HttpNotFound();
            }
            return View(candy);
        }

        // POST: Candies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type_of_Candy,Color_of_Candy,Number_of_Candies")] Candy candy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candy);
        }

        // GET: Candies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candy candy = db.Candies.Find(id);
            if (candy == null)
            {
                return HttpNotFound();
            }
            return View(candy);
        }

        // POST: Candies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candy candy = db.Candies.Find(id);
            db.Candies.Remove(candy);
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
