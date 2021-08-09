using Novus_Catalog.Models;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class RemoveController : Controller
    {
        private Entities db = new Entities();

        /// <summary>
        /// A function of the database web application that will allow mentors and adminstrators
        /// of the system to remove student records from the system
        /// </summary>
        public JsonResult Delete(int id)
        {
            STUDENT sTUDENT = db.STUDENTs.Find(id);
            db.STUDENTs.Remove(sTUDENT);
            db.SaveChanges();
            return Json(new { redirectToUrl = Url.Action("Student", "Default") });
        }
    }
}