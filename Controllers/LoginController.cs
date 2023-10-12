using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LoginFormInMvc.Models;

namespace LoginFormInMvc.Controllers
{
    public class LoginController : Controller
    {
        SignupLoginEntities db = new SignupLoginEntities();
        StudentContext studdb = new StudentContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var login = db.Users.Where(model => model.UserName == user.UserName && model.PassWord == user.PassWord).FirstOrDefault();
            if (login!= null)
            {
                //Session["UserId"] = user.Id.ToString();
                //Session["Username"] = user.UserName.ToString();
                TempData["LoginSuccessMessage"] = ViewBag.mybag = "<script>alert('Logged In')</script>";
                return RedirectToAction("CreateStudent", "Login");
            }
            else
            {
                 ViewBag.mybag = "<script>alert('Log in Properly')</script>";
                return View();
            }
            
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            if (ModelState.IsValid== true)
            {
                db.Users.Add(user);
               int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.mybag = "<script>alert('Registered')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    ViewBag.mybag = "<script>alert('Registeration Failed')</script>";
                }

            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid == true)
            {
                studdb.stud.Add(student);
                int a = studdb.SaveChanges();
                if (a > 0)
                {
                    ViewBag.mybag = "<script>alert('Created')</script>";
                    ModelState.Clear();
                    return RedirectToAction("EnterAcademicDetails", "Login");
                }
            }
            
            return View(student);
        }

        [HttpGet]
        public ActionResult EnterAcademicDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterAcademicDetails(StudentMarks marks)
        {
            if (ModelState.IsValid == true)
            {
                studdb.Marks.Add(marks);
                int a = studdb.SaveChanges();
                if (a > 0)
                {
                    ViewBag.mybag = "<script>alert('Created')</script>";
                    ModelState.Clear();
                    return RedirectToAction("AddWorkExperience", "Login");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddWorkExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWorkExperience(StudentExperience exp)
        {
            if (ModelState.IsValid == true)
            {
                studdb.Experience.Add(exp);
                int a = studdb.SaveChanges();
                if (a > 0)
                {
                    ViewBag.mybag = "<script>alert('Created')</script>";
                    ModelState.Clear();
                    return RedirectToAction("showprofile", "Login");
                }
                
            }

            return View();
        }

        public ActionResult showprofile() 
        {
            var getstudent = Student();
            var getstudentmarks = StudentMarks();
            var getstudentexperience = StudentExperience();

            StudentProfile profile = new StudentProfile();

            profile.StudentInfo = getstudent;
            profile.StudentMark = getstudentmarks;
            profile.StudnetExp = getstudentexperience;

            return View(profile);
        }

        public List<Student> Student()
        {
            return studdb.stud.ToList();           
        }

        public List<StudentMarks> StudentMarks()
        {
            return studdb.Marks.ToList();
        }

        public List<StudentExperience> StudentExperience()
        {
            return studdb.Experience.ToList();
        }

        public ActionResult DownloadCard()
        {
            var studentData = studdb.stud.FirstOrDefault();
            var marksData = studdb.Marks.FirstOrDefault();
            var expData = studdb.Experience.FirstOrDefault();

            if (studentData == null || marksData == null || expData == null)
            {

                return Content("Data not found.");
            }

            Document doc = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);

            doc.Open();

            PdfPTable table = new PdfPTable(2);
            table.TotalWidth = 400f;
            
            PdfPCell cell1 = new PdfPCell(new Phrase("Student Information"));
            cell1.Colspan = 2;
            cell1.BackgroundColor = new BaseColor(220, 220, 220);
            table.AddCell(cell1);

            table.AddCell("Name:");
            table.AddCell($"{studentData.FirstName} {studentData.LastName}");
            table.AddCell("Gender:");
            table.AddCell(studentData.Gender);

            PdfPCell cell2 = new PdfPCell(new Phrase("Marks Information"));
            cell2.Colspan = 2;
            cell2.BackgroundColor = new BaseColor(220, 220, 220);
            table.AddCell(cell2);

            table.AddCell("SSC:");
            table.AddCell($"{marksData.SSCPercentage}%");
            table.AddCell("HSC:");
            table.AddCell($"{marksData.HSCPercentage}%");

            PdfPCell cell3 = new PdfPCell(new Phrase("Exp Information"));
            cell3.Colspan = 2;
            cell3.BackgroundColor = new BaseColor(220, 220, 220);
            table.AddCell(cell3);

            table.AddCell("EXP:");
            table.AddCell(expData.HasWorkExperience ? "Yes" : "No");
            table.AddCell("COMPANY NAME:");
            table.AddCell(expData.CompanyName);

            doc.Add(table);

            doc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Card.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return Content("Download complete.");
        }

    }
}