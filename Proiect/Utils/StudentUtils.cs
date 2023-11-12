using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Proiect.Dto;
using Proiect.Dtos;
using System.Runtime.CompilerServices;

namespace Proiect.Utils
{
    public static class StudentUtils
    {
        public static StudentGetDto ToDto(this Student student)
        {
            if(student == null)
            {
                return null;
            }

            return new StudentGetDto { Id = student.Id, Name = student.Name, Age = student.Age };

        }


      

        public static GetStudentAddressDto ToDto(this Address studentAddress)
        {
            if (studentAddress == null)
            {
                return null;
            }
            return new GetStudentAddressDto { Id = studentAddress.Id, City = studentAddress.City, Number = studentAddress.Number, Street = studentAddress.Street };
        }

        public static Student ToEntity(this StudentCreateDto student)
        {
            if(student == null)
            {
                return null;
            }
            return new Student
            {
                Name = student.Name,
                Age = student.Age,
            };
        }

        public static Student ToEntity(this StudentUpdateDto student)
        {
            if (student == null)
            {
                return null;
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
            if(addressTuUpdate == null){
                return null;
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
