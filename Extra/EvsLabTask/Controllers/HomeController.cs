using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAC;
using EvsLabTask.Models;

namespace EvsLabTask.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            StudentModel student = null;
            List<StudentModel>studentList= new List<StudentModel>();
            foreach (var std in new StudentDACHandler().SelectAllStudents())
            {
                student=new StudentModel();
                student.Id = std.Id;
                student.Name = std.Name;
                student.FatherName = std.FatherName;
                student.Email = std.Email;
                studentList.Add(student);
            }
            // var Modal = studentList;
           ViewBag.Stds = studentList;
            return View();
        }


        [HttpPost]
        public ActionResult InsertStudent(Student student)
        {
            new StudentDACHandler().AddStudent(student);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditStudentLnk(int data)
        {
            //StudentModel student = new StudentModel();
            Student std= new StudentDACHandler().SelectStudentById(data);
            //student.Id         = std.Id;
            //student.Name       = std.Name;
            //student.FatherName = std.FatherName;
            //student.Email      = std.Email;

            ViewBag.Name       =  std.Name;             
            ViewBag.FatherName =  std.FatherName; 
            ViewBag.Email = std.Email;
            ViewBag.Id         =std.Id;

            return PartialView("_Edit");
        }


        public ActionResult EditStudentConfirm(Student student)
        {

            new StudentDACHandler().UpdateStudent(student);
            return RedirectToAction("Index");
        }



     
        public ActionResult DeleteLnk(int data)
        {
            ViewBag.Id = data;
            ViewBag.Message = "Do you want to delete this Record ? ";
            return PartialView("_Dialog");
        }
[HttpPost]
        public ActionResult DeleteConfirm(int data)
        {

            new StudentDACHandler().DeleteStudent(data);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult ViewStudent()
        {
            return RedirectToAction("Index");
        }


    }
}