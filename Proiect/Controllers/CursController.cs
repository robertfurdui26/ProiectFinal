using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Proiect.Dto;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public CursController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Add Course 
        /// </summary>
        /// 
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpPost("addCurs")]
        public IActionResult AddCourseStudent([FromBody] string courseName)
        {
            try
            {
                var course = dal.AddCourse(courseName);
                return Ok(course);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get All Courses
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK ,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpGet("getAllCoursesSTudent")]
        public List<Course> GetAllMark() => dal.GetAllCursuri();
    }
}
