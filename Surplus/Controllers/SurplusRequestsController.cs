using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Surplus.DataAccess;
using Surplus.Models;

namespace Surplus.Controllers
{
    public class SurplusRequestsController : Controller
    {
        private SurplusDbContext db = new SurplusDbContext();

        // GET: SurplusRequests
        //public ActionResult Index()
        //{
        //    var surplusRequests = db.SurplusRequests.Include(s => s.ItemCondition).Include(s => s.QuantityDescription);
        //    return View(surplusRequests.ToList());
        //}

        // GET: SurplusRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SurplusRequest surplusRequest = db.SurplusRequests
                .Include(s => s.ItemCondition)
                .Include(s => s.QuantityDescription)
                .SingleOrDefault(s => s.Id == id);

            if (surplusRequest == null)
            {
                return HttpNotFound();
            }

            return View(surplusRequest);
        }

        // GET: SurplusRequests/Create
        public ActionResult Create()
        {
            ViewBag.ItemConditionId = new SelectList(db.ItemConditions, "Id", "Name")
                .OrderBy(c => c.Text);
            ViewBag.QuantityDescriptionId = new SelectList(db.QuantityDescriptions, "Id", "Name")
                .OrderBy(c => c.Text);

            return View(new SurplusRequest());
        }

        // POST: SurplusRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VTBarcode,Description,Manufacturer,Model,SerialNumber,Quantity,QuantityDescriptionId,EstimatedValue,ItemConditionId,DepartmentNumber,DepartmentDescription,Building,FloorLevel,ContactName,ContactPhone,AuthorizerName,AdditionalDetails")] SurplusRequest surplusRequest)
        {
            if (ModelState.IsValid)
            {
                surplusRequest.UserName = 
                    String.IsNullOrEmpty(HttpContext.User.Identity.Name) ?
                    null : HttpContext.User.Identity.Name;
                 
                db.SurplusRequests.Add(surplusRequest);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = surplusRequest.Id });
            }

            ViewBag.ItemConditionId = new SelectList(db.ItemConditions, "Id", "Name")
                .OrderBy(c => c.Text);
            ViewBag.QuantityDescriptionId = new SelectList(db.QuantityDescriptions, "Id", "Name")
                .OrderBy(c => c.Text);
            
            return View(surplusRequest);
        }

        // GET: SurplusRequests/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SurplusRequest surplusRequest = db.SurplusRequests.Find(id);
        //    if (surplusRequest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ItemConditionId = new SelectList(db.ItemConditions, "Id", "Name", surplusRequest.ItemConditionId);
        //    ViewBag.QuantityDescriptionId = new SelectList(db.QuantityDescriptions, "Id", "Name", surplusRequest.QuantityDescriptionId);
        //    return View(surplusRequest);
        //}

        // POST: SurplusRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,VTBarcode,Description,Manufacturer,Model,SerialNumber,Quantity,QuantityDescriptionId,EstimatedValue,ItemConditionId,DepartmentNumber,DepartmentDescription,Building,FloorLevel,ContactName,ContactPhone,AuthorizerName,AdditionalDetails")] SurplusRequest surplusRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(surplusRequest).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ItemConditionId = new SelectList(db.ItemConditions, "Id", "Name", surplusRequest.ItemConditionId);
        //    ViewBag.QuantityDescriptionId = new SelectList(db.QuantityDescriptions, "Id", "Name", surplusRequest.QuantityDescriptionId);
        //    return View(surplusRequest);
        //}

        // GET: SurplusRequests/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SurplusRequest surplusRequest = db.SurplusRequests.Find(id);
        //    if (surplusRequest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(surplusRequest);
        //}

        // POST: SurplusRequests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    SurplusRequest surplusRequest = db.SurplusRequests.Find(id);
        //    db.SurplusRequests.Remove(surplusRequest);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
