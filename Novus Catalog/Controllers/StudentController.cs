using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Novus_Catalog.Models;

namespace Novus_Catalog.Controllers
{
    public class StudentController : Controller
    {
        private Entities db = new Entities();

        //public ActionResult Index()
        //{
        //    return View(db.STUDENTs.ToList());
        //}

        /// <summary>
        /// A function of the database web application that allows mentors and administrators
        /// of the system to create student records in the system
        /// </summary>
        //public ActionResult Create()
        //{
        //    return View();
        //}
                
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "null, SFIRSTNAME, SLASTNAME, GENDER, ADDRESS, CITY, DEPARTMENT, SCHOOL, PFIRSTNAME, PLASTNAME, PHONE_NUMBER, DATE_ENROLLED, ATTENDANCE")]STUDENT sTUDENT)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.STUDENTs.Add(sTUDENT);
        //            db.SaveChanges();
        //            return RedirectToAction("Index", "Student");
        //        }

        //    }
        //    catch (DataException)
        //    {
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //    }

        //    return View(sTUDENT);
        //}

        //[HttpPost]
        //public ActionResult User()
        //{
        //    return RedirectToAction("Index", "Student");
        //}

        /// <summary>
        /// A function of the database web application that will allow mentors and adminstrators
        /// of the system to modify student records from the system
        /// </summary>
        //public ActionResult Edit(int? id)
        //{
        //    var std = db.STUDENTs.Where(s => s.SID == id).FirstOrDefault();
            
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    STUDENT sTUDENT = db.STUDENTs.Find(id);

        //    if (sTUDENT == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(std);
        //}

        //// POST: Student/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "SID, SFIRSTNAME, SLASTNAME, GENDER, ADDRESS, CITY, DEPARTMENT, SCHOOL, PFIRSTNAME, PLASTNAME, PHONE_NUMBER, DATE_ENROLLED, ATTENDANCE")] STUDENT sTUDENT)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sTUDENT).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Student");
        //    }
        //    return View(sTUDENT);
        //}

        ///// <summary>
        ///// A function of the database web application that will allow mentors and adminstrators
        ///// of the system to remove student records from the system
        ///// </summary>
        //public JsonResult Delete(int id)
        //{
        //    STUDENT sTUDENT = db.STUDENTs.Find(id);
        //    db.STUDENTs.Remove(sTUDENT);
        //    db.SaveChanges();
        //    return Json(new { redirectToUrl = Url.Action("Index", "Student") });
        //}

        /// <summary>
        /// A function that will allow administrative users to export 
        /// documents in a excel format that could be used for data manipulation 
        /// and/or analytics purposes
        /// </summary>
        //public void GenerateReport()
        //{
        //    var data = from s in  db.STUDENTs
        //    select new { FirstName = s.SFIRSTNAME, LastName = s.SLASTNAME, Gender = s.GENDER, Address = s.ADDRESS, City = s.CITY, Department = s.DEPARTMENT, School = s.SCHOOL, ParentFirstName = s.PFIRSTNAME, ParentLastName = s.PLASTNAME, PhoneNumber = s.PHONE_NUMBER,
        //    EnrollmentDate = s.DATE_ENROLLED, Attendance = s.ATTENDANCE };

        //    var list = data.ToList();
        //    var grid = new System.Web.UI.WebControls.GridView();
        //    grid.DataSource = list;
        //    grid.DataBind();
        //    Response.ClearContent();
        //    string outputFileName = string.Format("{0}_{1}.xls", "Student", DateTime.Now.ToString("yyyyMMdd"));
        //    Response.AddHeader("content-disposition", "attachment; filename=" + outputFileName);
        //    Response.ContentType = "application/vnd.ms-excel;name='excel'";         
        //    StringWriter sw = new StringWriter();
        //    System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        //    grid.RenderControl(htw);
        //    Response.Write(sw.ToString());
        //    Response.End();
        //}

    }
}
