﻿
using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        private readonly StudentDbContext ctx;
        public DataAccessLayerService(StudentDbContext ctx) 
        {
            this.ctx = ctx;
        }

        public IEnumerable<Student> GetAllStudents() => ctx.Students.ToList();
        public Student GetStudentById(int id) => ctx.Students.FirstOrDefault(s => s.Id == id);
        public IEnumerable<Student> GetStudentByAverageOrder()
        {
            try
            {
                var students = ctx.Students.ToList();
                var studentAverageList = students
            .OrderByDescending(s => s.CalculateTotalAverage()).Select(s => new Student
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                StudentTotalAverage = s.CalculateTotalAverage()
            }).ToList();

                return studentAverageList;
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"Eroare la obținerea studentului: {ex.Message}");
                throw;
            }
        }    
        public Address GetStudentAddress(int studentId)
        {
            var student = ctx.Students.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                return student.Address;
            }
            return null;

        }
        public Student CreateStudent(Student student)
        {

            if (ctx.Students.Any(s => s.Id == student.Id))
            {
                //throw exception
            }

            ctx.Students.Add(student);
            ctx.SaveChanges();
            return student;
        }

        public Student Update(Student studentToUpdate)
        {


            var student = ctx.Students.FirstOrDefault(s => s.Id == studentToUpdate.Id);
            if (student == null)
            {
                return null;
            }

            student.Name = studentToUpdate.Name;
            student.Age = studentToUpdate.Age;

            ctx.SaveChanges();
            return student;
        }

        public bool UpdateOrCreateStudentAddres(int studentId, Address nouaAdresa)
        {


            var student = ctx.Students.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                //exception
            }

            var created = false;

            if (student.Address == null)
            {
                student.Address = new Address();
                created = true;
            }
            student.Address.Number = nouaAdresa.Number;
            student.Address.City = nouaAdresa.City;
            student.Address.Street = nouaAdresa.Street;

            ctx.SaveChanges();
            return created;
        }

        public void DeleteStudent(int studentId)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new InvalidIdException($"student not found{studentId}");
            }

            ctx.Students.Remove(student);
            ctx.SaveChanges();
        }
    }
}
