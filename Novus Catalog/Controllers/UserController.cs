using Novus_Catalog.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class UserController : Controller
    {
        private Entities db = new Entities();

        [HttpPost]
        public ActionResult User()
        {
            return RedirectToAction("Student", "Default");
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(USER userObj, string oldAdminPwd, string newAdminPwd, string newMentorPwd, string oldMentorPwd)
        {
            SqlConnection con = null;
            SqlCommand cmd;
            int rowsAffected = 0;
            int taskComplete = 0;

            if (!String.IsNullOrEmpty(newAdminPwd) || !String.IsNullOrEmpty(oldAdminPwd))
            {
                if (String.IsNullOrEmpty(oldAdminPwd) || String.IsNullOrEmpty(newAdminPwd))
                {
                    ModelState.AddModelError("", "Error: Both administrator passwords must be set.");
                }
                else
                {
                    newAdminPwd = newAdminPwd.Trim();
                    oldAdminPwd = oldAdminPwd.Trim();

                    try
                    {
                        using (con = new SqlConnection(@"Data Source=DESKTOP-LGGS6QI\SQLEXPRESS;Initial Catalog=my.novus;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"))
                        {
                            using (cmd = new SqlCommand(@"SELECT COUNT(*) FROM USERS WHERE ACCOUNT = 'Administrator' AND PASS = @oldAdminPwd", con))
                            {
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Parameters.AddWithValue("@oldAdminPwd", oldAdminPwd);

                                con.Open();

                                rowsAffected = (int)cmd.ExecuteScalar();

                                if (rowsAffected < 1)
                                {
                                    return RedirectToAction("Edit", "User");
                                }
                                else
                                {
                                    cmd = new SqlCommand("Update USERS set PASS = @newAdminPwd Where ACCOUNT = 'Administrator'", con);

                                    cmd.Parameters.AddWithValue("@newAdminPwd", newAdminPwd);

                                    taskComplete = cmd.ExecuteNonQuery();

                                    if (taskComplete < 1)
                                    {
                                        ModelState.AddModelError("", "Error: Invalid query for the new administrator password.");
                                        System.Environment.Exit(0);
                                    }

                                }

                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Failure");
                    }

                }

            }//

            if (!String.IsNullOrEmpty(newMentorPwd) || !String.IsNullOrEmpty(oldMentorPwd))
            { 
                if (String.IsNullOrEmpty(oldMentorPwd) || String.IsNullOrEmpty(newMentorPwd))
                {
                    ModelState.AddModelError("", "Error: Both administrator passwords must be set.");
                }
                else
                {
                    newMentorPwd = newMentorPwd.Trim();
                    oldMentorPwd = oldMentorPwd.Trim();

                    try
                    {
                        using (con = new SqlConnection(@"Data Source=DESKTOP-LGGS6QI\SQLEXPRESS;Initial Catalog=my.novus;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"))
                        {
                            using (cmd = new SqlCommand(@"SELECT COUNT(*) FROM USERS WHERE ACCOUNT = 'Mentor' AND PASS = @oldMentorPwd", con))
                            {
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Parameters.AddWithValue("@oldMentorPwd", oldMentorPwd);

                                if (!(con.State == System.Data.ConnectionState.Open))
                                {
                                    con.Open();
                                }

                                rowsAffected = (int)cmd.ExecuteScalar();

                                if (rowsAffected < 1)
                                {
                                    return RedirectToAction("Edit", "User");
                                }
                                else
                                {
                                    cmd = new SqlCommand("Update USERS set PASS = @newMentorPwd Where ACCOUNT = 'Mentor'", con);

                                    cmd.Parameters.AddWithValue("@newMentorPwd", newMentorPwd);

                                    taskComplete = cmd.ExecuteNonQuery();

                                    if (taskComplete < 1)
                                    {
                                        ModelState.AddModelError("", "Error: Invalid query for the new mentor password.");
                                        System.Environment.Exit(0);
                                    }

                                }

                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Failure");
                    }

                }

            }

            if (String.IsNullOrEmpty(newAdminPwd) || String.IsNullOrEmpty(oldAdminPwd) 
                || String.IsNullOrEmpty(newMentorPwd) || String.IsNullOrEmpty(oldMentorPwd))
            {
                return View();
            }

            return RedirectToAction("Student", "Default");

        }

    }
}