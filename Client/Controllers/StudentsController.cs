using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client.Models;
using Client.ViewModels;

namespace Client.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            StudentClient sc = new StudentClient();
            ViewBag.listStudents = sc.findAll();
            return View();
        }

        // CREATE: Students 
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(StudentViewModels svm)
        {
            StudentClient sc = new StudentClient();
            sc.create(svm.Student);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            StudentClient sc = new StudentClient();
            StudentViewModels svm = new StudentViewModels();
            svm.Student = sc.find(id);

            return View("Edit",svm);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModels svm)
        {
            StudentClient sc = new StudentClient();
            sc.edit(svm.Student);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            StudentClient sc = new StudentClient();
            sc.delete(id);
            return RedirectToAction("Index");
        }
    }
}