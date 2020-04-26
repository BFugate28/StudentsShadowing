using StudentsShadowing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsShadowing.Services
{
    public interface IStudentsShadowingRepository
    {
        Student Create(Student student);
        Student ReadStudent(int id);
        ICollection<Student> ReadAllStudents();
        void Update(int id, Student student);
        void Delete(int id);

        Professional CreateProfessional(int studentId, Professional professional);
        Professional ReadProfessional(int id);
        void UpdateProfessional(int studentId, int recId, Professional professional);
        void DeleteProfessional(int studentId, int professionalId);
    }
}
