using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsShadowing.Models.ViewModels;
using StudentsShadowing.Services;

namespace StudentsShadowing.Controllers
{
    public class ProfessionalController : Controller
    {
        private IStudentsShadowingRepository _repo;

        public ProfessionalController(IStudentsShadowingRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index([Bind(Prefix = "id")]int studentId)
        {
            var student = _repo.ReadStudent(studentId);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Create([Bind(Prefix ="id")]int studentId)
        {
            var student = _repo.ReadStudent(studentId);
            if(student == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["Student"] = student;
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(int studentId, CreateProfessionalVM createProfessionalVM)
        {
            if(ModelState.IsValid)
            {
                var professional = createProfessionalVM.GetProfessionalInstance();
                _repo.CreateProfessional(studentId, professional);
                return RedirectToAction("Details", "Student", new { id = studentId });
            }
            ViewData["Student"] = _repo.ReadStudent(studentId);
            return View(createProfessionalVM);
        }

        public IActionResult Edit([Bind(Prefix ="id")] int studentId,int recId)
        {
            var student = _repo.ReadStudent(studentId);
            if(student == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var professional = student.Professionals.FirstOrDefault(r => r.Id == recId);
            if(professional == null)
            {
                return RedirectToAction("Details", "Student", new { id = studentId });
            }
            var editProfessionalVM = new EditProfessionalVM
            {
                Id = professional.Id,
                Name = professional.Name,
                Category = professional.Category
            };
            ViewData["Student"] = student;
            return View(editProfessionalVM);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(int studentId, EditProfessionalVM editProfessionalVM)
        {
            if(ModelState.IsValid)
            {
                var editRec = editProfessionalVM.GetEditProfessionalInstance();
                _repo.UpdateProfessional(studentId, editRec.Id, editRec);
                return RedirectToAction("Details", "Student", new { id = studentId });
            }
            ViewData["Student"] = _repo.ReadStudent(studentId);
            return View(editProfessionalVM);
        }

        public IActionResult Details([Bind(Prefix ="id")]int Id)
        {
            var professional = _repo.ReadProfessional(Id);
            if(professional != null)
            {
                var model = new ProfessionalDetails
                {
                    Id = professional.Id,
                    Name = professional.Name,
                    Category = professional.Category
                };
                return View(model);
            }
            return RedirectToAction("Details", "Professional");
        }

        public IActionResult Delete ([Bind(Prefix ="id")]int studentId, int recId)
        {
            var student = _repo.ReadStudent(studentId);
            if(student == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var professional = student.Professionals.FirstOrDefault(r => r.Id == recId);
            if(professional == null)
            {
                return RedirectToAction("Details", "Student", new { id = studentId });
            }
            ViewData["Student"] = student;
            return View(professional);
                
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id, int studentId)
        {
            _repo.DeleteProfessional(studentId, id);
            return RedirectToAction("Details", "Student", new { id = studentId });
        }

    }
}