using Novus_Catalog.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class ReportController : Controller
    {
        private Entities db = new Entities();

        /// <summary>
        /// A function that will allow administrative users to export 
        /// documents in a excel format that could be used for data manipulation 
        /// and/or analytics purposes
        /// </summary>
        public void GenerateReport()
        {
            var data = from s in db.STUDENTs
                       select new
                       {
                           FirstName = s.SFIRSTNAME,
                           LastName = s.SLASTNAME,
                           Gender = s.GENDER,
                           Address = s.ADDRESS,
                           City = s.CITY,
                           Department = s.DEPARTMENT,
                           School = s.SCHOOL,
                           ParentFirstName = s.PFIRSTNAME,
                           ParentLastName = s.PLASTNAME,
                           PhoneNumber = s.PHONE_NUMBER,
                           EnrollmentDate = s.DATE_ENROLLED,
                           Attendance = s.ATTENDANCE
                       };

            var list = data.ToList();
            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = list;
            grid.DataBind();
            Response.ClearContent();
            string outputFileName = string.Format("{0}_{1}.xls", "Student", DateTime.Now.ToString("yyyyMMddhmmss"));
            Response.AddHeader("content-disposition", "attachment; filename=" + outputFileName);
            Response.ContentType = "application/vnd.ms-excel;name='excel'";
            StringWriter sw = new StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}