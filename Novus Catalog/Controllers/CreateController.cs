using Novus_Catalog.Models;
using System.Data;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class CreateController : Controller
    {
        private Entities db = new Entities();

        [HttpPost]
        public ActionResult User()
        {
            return RedirectToAction("Student", "Default");
        }

        /// <summary>
        /// A function of the database web application that allows mentors and administrators
        /// of the system to create student records in the system
        /// </summary>
        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Student([Bind(Include = "null, SFIRSTNAME, SLASTNAME, GENDER, ADDRESS, CITY, DEPARTMENT, SCHOOL, PFIRSTNAME, PLASTNAME, PHONE_NUMBER, DATE_ENROLLED, ATTENDANCE")]STUDENT sTUDENT)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.STUDENTs.Add(sTUDENT);
                    db.SaveChanges();
                    return RedirectToAction("Student", "Default");
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(sTUDENT);
        }

    }
}