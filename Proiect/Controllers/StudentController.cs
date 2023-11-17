using Data;
using Data.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Proiect.Dto;
using Proiect.Dtos;
using Proiect.Utils;
using System.ComponentModel.DataAnnotations;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;

        public StudentController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Get All Students
        /// </summary>
        /// <returns>A list of all students from database</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IEnumerable<StudentGetDto> GetAllStudents()
        {
            var allStudents = dal.GetAllStudents();
            return allStudents.Select(s => StudentUtils.ToDto(s)).ToList();
        }

        /// <summary>
        /// Ordered Students List By Average
        /// </summary>
        /// <returns>A list of students ordered by average grades</returns>
        [HttpGet("averageListOrdered")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderStudentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<IEnumerable<OrderStudentDto>> GetStudentByAverageOrder()
        {
            try
            {
                var studentByAverageOrder = dal.GetStudentByAverageOrder();
                return Ok(studentByAverageOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }
        }

            /// <summary>
            /// Get Student By Id
            /// </summary>
            /// <param name="id">Student Id</param>
            /// <returns>Return a student by his id from database</returns>
            [HttpGet("/getSt/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK ,Type = typeof(StudentGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest ,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

        public StudentGetDto GetStudentById([Range(1, int.MaxValue)] int id) =>     
            dal.GetStudentById(id).ToDto();

        /// <summary>
        /// Get Studen tAddress
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>Return student address from database</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentAddressDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public StudentAddressDto GetStudentAddress(int id ) =>
            dal.GetStudentAddress(id).ToDto();

        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="studentToCreate">studentToCreate</param>
        /// <returns>Create a student data</returns>
        [HttpPost("createStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public StudentGetDto CreateStudent([FromBody] StudentCreateDto studentToCreate) =>
            dal.CreateStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="studentUpdate">studentToUpdate</param>
        /// <returns>Return a new student updated</returns>
        [HttpPatch("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentUpdateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public StudentGetDto UpdateStudent([FromBody] StudentUpdateDto studentUpdate) =>     
            dal.Update(studentUpdate.ToEntity()).ToDto();

    

        /// <summary>
        ///Delete Student
        /// </summary>
        /// <param name="id">StudentId</param>
        /// <returns>Delete a student from database</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                dal.DeleteStudent(id);

            }
            catch(InvalidIdException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        
    }
}
