using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolModel.Entities;
using SchoolModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloMvc.Controllers
{
    public class StudentController : Controller
    {
        #region Prop
        private readonly ILogger<StudentController> _logger;
        private readonly IDidactisService didacticsService;
        #endregion

        public StudentController(ILogger<StudentController> logger, IDidactisService didacticsService) 
        {
            this._logger = logger;
            this.didacticsService = didacticsService;
        }

        public IActionResult Index()
        {
            var students = didacticsService.GetAllStudents().ToList();
            return View(students);
        }
        public IActionResult List(string lastnameLike)
        {
            var students = didacticsService.GetStudentsByLastnameLike(lastnameLike);
            return View(students);
        }

        public IActionResult Details(long id) 
        {
            var student = didacticsService.GetStudentById(id);
            return View(student);
        }
        public IActionResult Create() 
        {
            return View();
        }
        public IActionResult Edit(long id) 
        {
            var s = didacticsService.GetStudentById(id);
            return View(s);
        }
        public IActionResult Delete(long id) 
        {
            var s = didacticsService.GetStudentById(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult Create(Student s) 
        {
            if (ModelState.IsValid) 
            {
                didacticsService.CreateStudent(s);
                return RedirectToAction("Index");
            }
            return View(s);
        }
        [HttpPost]
        public IActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                didacticsService.UpdateStudent(s);
                return RedirectToAction("Index");
            }
            return View(s);
        }
        [HttpPost]
        public IActionResult Delete(Student s)
        {
            didacticsService.Delete(s);
            return RedirectToAction("Index");
        }

    }
}
