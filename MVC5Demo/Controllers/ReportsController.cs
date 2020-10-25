using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class ReportsController : Controller
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();

        StringBuilder sb = new StringBuilder();

        public ReportsController()
        {
            db.Database.Log = (msg) =>
            {
                sb.AppendLine(msg);
                sb.AppendLine("-----------------------------------------");
            };
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CoursesReport1()
        {
            var data = (from c in db.Course
                       select new CoursesReport1VM()
                       {
                           CourseID = c.CourseID,
                           CourseName = c.Title,
                           StudentCount = c.Enrollments.Count(),
                           TeacherCount = c.Teachers.Count(),
                           AvgGrade = c.Enrollments.Where(e => e.Grade.HasValue).Average(e => e.Grade.Value)
                       }).ToList();

            ViewBag.SQL = sb.ToString();

            return View(data);
        }

        public ActionResult CoursesReport2()
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"
SELECT
    Course.CourseID, 
    Course.Title AS CourseName,
	(SELECT COUNT(CourseID) FROM CourseInstructor WHERE (CourseID = Course.CourseID)) AS TeacherCount,
	(SELECT COUNT(CourseID) FROM Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS StudentCount,
	(SELECT AVG(Cast(Grade as Float)) FROM Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS AvgGrade
FROM   Course
GROUP BY Course.CourseID, Course.Title").ToList();

            ViewBag.SQL = sb.ToString();

            return View("CoursesReport1", data);
        }

        public ActionResult CoursesReport3(int id)
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"
SELECT
    Course.CourseID, 
    Course.Title AS CourseName,
	(SELECT COUNT(CourseID) FROM CourseInstructor WHERE (CourseID = Course.CourseID)) AS TeacherCount,
	(SELECT COUNT(CourseID) FROM Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS StudentCount,
	(SELECT AVG(Cast(Grade as Float)) FROM Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS AvgGrade
FROM   Course
WHERE  Course.CourseID = @p0
GROUP BY Course.CourseID, Course.Title", id).ToList();

            ViewBag.SQL = sb.ToString();

            return View("CoursesReport1", data);
        }
    }
}