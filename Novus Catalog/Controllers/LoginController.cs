using Novus_Catalog.Models;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult User()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult User(USER objUser)
        {
            if (ModelState.IsValid)
            {
                using (Entities db = new Entities())
                {
                    var obj = db.USERS.Where(a => a.ACCOUNT.Equals(objUser.ACCOUNT)
                    && a.PASS.Equals(objUser.PASS)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ACCOUNT"] = obj.ACCOUNT.ToString();
                        Session["PASS"] = obj.PASS.ToString();
                        return RedirectToAction("Student", "Default");

                    }
                    else
                    {
                        ModelState.AddModelError("", "The password you entered could not be found. Please try again.");
                    }

                }
            }
            return View(objUser);

        }

    }
}
