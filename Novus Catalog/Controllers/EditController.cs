using Novus_Catalog.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class EditController : Controller
    {
        private Entities db = new Entities();

        [HttpPost]
        public ActionResult User()
        {
            return RedirectToAction("Student", "Default");
        }

        /// <summary>
        /// A function of the database web application that will allow mentors and adminstrators
        /// of the system to modify student records from the system
        /// </summary>
        public ActionResult Student(int? id)
        {
            var std = db.STUDENTs.Where(s => s.SID == id).FirstOrDefault();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            STUDENT sTUDENT = db.STUDENTs.Find(id);

            if (sTUDENT == null)
            {
                return HttpNotFound();
            }

            return View(std);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Student([Bind(Include = "SID, SFIRSTNAME, SLASTNAME, GENDER, ADDRESS, CITY, DEPARTMENT, SCHOOL, PFIRSTNAME, PLASTNAME, PHONE_NUMBER, DATE_ENROLLED, ATTENDANCE")] STUDENT sTUDENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Student", "Default");
            }
            return View(sTUDENT);
        }

    }
}