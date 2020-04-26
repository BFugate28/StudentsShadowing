using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsShadowing.DataContexts;
using StudentsShadowing.Models.Entities;

namespace StudentsShadowing.Services
{
    public class DbStudentsShadowingRepository : IStudentsShadowingRepository
    {
        private StudentsShadowingDbContext _db;

        public DbStudentsShadowingRepository(StudentsShadowingDbContext db)
        {
            _db = db;
        }

        public Student Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }

        public Student ReadStudent(int id)
        {
            return _db.Students.Include(s => s.Professionals).FirstOrDefault(s => s.Id == id);
        }

        public ICollection<Student> ReadAllStudents()
        {
            return _db.Students.Include(s => s.Professionals).ToList();
        }

        public void Update(int id, Student student)
        {
            var oldStudent = ReadStudent(id);
            if(oldStudent != null)
            {
                oldStudent.Name = student.Name;
                oldStudent.Age = student.Age;
                oldStudent.Interest = student.Interest;

                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var student = ReadStudent(id);
            if(student != null)
            {
                _db.Remove(student);
                _db.SaveChanges();
            }
        }



        public Professional CreateProfessional(int studentId, Professional professional)
        {
            Student student = ReadStudent(studentId);
            if(student != null)
            {
                _db.Professionals.Add(professional);
                professional.Student = student;
                _db.SaveChanges();
            }
            return professional;
        }

        public Professional ReadProfessional(int id)
        {
            return _db.Professionals.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProfessional(int studentId, int recId, Professional professional)
        {
            var student = ReadStudent(studentId);
            if (student != null)
            {
                var oldProfessional = student.Professionals.FirstOrDefault(p => p.Id == professional.Id);
                if(oldProfessional != null)
                {
                    oldProfessional.Name = professional.Name;
                    oldProfessional.Category = professional.Category;
                    _db.SaveChanges();
                }
            }
        }


        public void DeleteProfessional(int studentId, int professionalId)
        {
            var student = ReadStudent(studentId);
            if(student != null)
            {
                var professional = student.Professionals.FirstOrDefault(p => p.Id == professionalId);
                if(professional != null)
                {
                    student.Professionals.Remove(professional);
                    _db.SaveChanges();
                }
            }
        }

    }
}
