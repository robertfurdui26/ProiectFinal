using Data.Models;
using Proiect.Dto;
using Proiect.Dtos;
using System.Reflection.Metadata.Ecma335;

namespace Proiect.Utils
{
    public static class StudentUtils
    {
        public static StudentGetDto ToDto(this Student student) =>
            student is null
            ? throw new Exception($"Student not found {student}")
            : new StudentGetDto { Id = student.Id, Name = student.Name, Age = student.Age };

        public static StudentAddressDto ToDto(this Address studentAddress) =>
            studentAddress is null
            ? throw new Exception($"Address not found {studentAddress}")
            :  new StudentAddressDto { Id = studentAddress.Id , City = studentAddress.City , Number = studentAddress.Number , Street = studentAddress.Street};

        public static Student ToEntity(this StudentCreateDto student) =>
            student is null
            ? throw new Exception($"Student not found {student}")
            : new Student
            {
                Name = student.Name,
                Age = student.Age,
            };

        public static Student ToEntity(this StudentUpdateDto student)
        {
            if (student == null)
            {
                throw new Exception($"Student cannot found! {student}");
            }
            return new Student
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
            };
        }

        public static Address ToEntity(this AddressTuUpdateDto addressTuUpdate)
        {
            if(addressTuUpdate == null)
            {
                throw new Exception($"Address not found {addressTuUpdate}");
            }

            return new Address
            {
                Number = addressTuUpdate.Number,
                City = addressTuUpdate.City,
                Street = addressTuUpdate.Street
            };
        }


    }
}
