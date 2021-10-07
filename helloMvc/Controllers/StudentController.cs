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

    }
}
