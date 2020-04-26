using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsShadowing.Models.Entities;
using StudentsShadowing.Models.ViewModels;
using StudentsShadowing.Services;

namespace StudentsShadowing.Controllers
{
    public class StudentController : Controller
    {
        private IStudentsShadowingRepository _repo;

        public StudentController(IStudentsShadowingRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var model = _repo.ReadAllStudents();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentVm createStudentVm)
        {
            if(ModelState.IsValid)
            {
                var student = createStudentVm.GetStudentInstance();
                _repo.Create(student);
                return RedirectToAction("Index", "Home");
            }
            return View(createStudentVm);
        }

        public IActionResult Edit(int id)
        {
            var student = _repo.ReadStudent(id);
            if(student == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(student);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                _repo.Update(student.Id, student);
                return RedirectToAction("Index", "Home");
            }
            return View(student);
        }

        public IActionResult Details(int id)
        {
            var student = _repo.ReadStudent(id);
            if(student != null)
            {
                var model = new StudentDetailsVM
                {
                    Id = student.Id,
                    Name = student.Name,
                    Interest = student.Interest,
                    Professionals = student.Professionals
                };
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete (int id)
        {
            var student = _repo.ReadStudent(id);
            if(student == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(student);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            _repo.Delete(Id);
            return RedirectToAction("Index", "Home");
        }
    }
}