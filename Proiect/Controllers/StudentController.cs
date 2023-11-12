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
        /// <returns></returns>
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
        /// Order StudentList By Average
        /// </summary>
        /// <returns></returns>
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
            /// GetStudentById
            /// </summary>
            /// <param name="id"></param>
            /// <returns>student data</returns>
            [HttpGet("/id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK ,Type = typeof(StudentGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest ,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

        public StudentGetDto GetStudentById([Range(1, int.MaxValue)] int id) =>     
            dal.GetStudentById(id).ToDto();

        /// <summary>
        /// GetStudentAddress
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetStudentAddressDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public GetStudentAddressDto GetStudentAddress(int id ) =>
            dal.GetStudentAddress(id).ToDto();

        /// <summary>
        /// CreateStudent
        /// </summary>
        /// <param name="studentToCreate">student to create data</param>
        /// <returns>create student data</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public StudentGetDto CreateStudent([FromBody] StudentCreateDto studentToCreate) =>
            dal.CreateStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="studentUpdate"></param>
        /// <returns></returns>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentUpdateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public StudentGetDto UpdateStudent([FromBody] StudentUpdateDto studentUpdate) =>     
            dal.Update(studentUpdate.ToEntity()).ToDto();

    

        /// <summary>
        ///DeleteStudent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
