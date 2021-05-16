using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RejestOsob.Models;

namespace RejestOsob.Controllers
{
    public class LostPersonsController : Controller
    {
        private PersonEntities db = new PersonEntities();

        // GET: LostPersons









        public ActionResult Index(int GenderSelected=0)
        {
            
            
                var items = db.Gender.ToList();
               
                    ViewBag.data = items;
                var lostPerson = db.LostPerson.ToList();


                if (GenderSelected == 0)
                {
                    lostPerson = db.LostPerson.ToList();
                }
                else
                 lostPerson = db.LostPerson.Where(a => a.Gender1.Id == GenderSelected).ToList();

                return View(lostPerson.ToList());
            
        }



       




        // GET: LostPersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPerson lostPerson = db.LostPerson.Find(id);
            if (lostPerson == null)
            {
                return HttpNotFound();
            }
            return View(lostPerson);
        }
        [Authorize]
        // GET: LostPersons/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new SelectList(db.Gender, "Id", "Name");
            return View();
        }

        // POST: LostPersons/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPerson,name,lastname,BDate,Photo,Describe,Gender,LostDate,LostPlace")] LostPerson lostPerson)
        {
            if (ModelState.IsValid)
            {
                db.LostPerson.Add(lostPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Gender = new SelectList(db.Gender, "Id", "Name", lostPerson.Gender);
            return View(lostPerson);
        }
        [Authorize(Roles = "Administrator")]
        // GET: LostPersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPerson lostPerson = db.LostPerson.Find(id);
            if (lostPerson == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gender = new SelectList(db.Gender, "Id", "Name", lostPerson.Gender);
            return View(lostPerson);
        }

        // POST: LostPersons/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPerson,name,lastname,BDate,Photo,Describe,Gender,LostDate,LostPlace")] LostPerson lostPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lostPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender = new SelectList(db.Gender, "Id", "Name", lostPerson.Gender);
            return View(lostPerson);
        }
        [Authorize(Roles = "Administrator")]
        // GET: LostPersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPerson lostPerson = db.LostPerson.Find(id);
            if (lostPerson == null)
            {
                return HttpNotFound();
            }
            return View(lostPerson);
        }

        // POST: LostPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LostPerson lostPerson = db.LostPerson.Find(id);
            db.LostPerson.Remove(lostPerson);
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
