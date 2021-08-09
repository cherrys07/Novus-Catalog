using Novus_Catalog.Models;
using System.Linq;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class DefaultController : Controller
    {        
        private Entities db = new Entities();

        // GET: Default
        public ActionResult Student()
        {
            return View(db.STUDENTs.ToList());
        }
    }
}