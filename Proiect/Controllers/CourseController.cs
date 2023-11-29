using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Proiect.Dto;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public CourseController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Add Course
        /// </summary>
        /// <param name="courseName">courseName</param>
        /// <returns>We create a course and store in database</returns>
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
        /// Get All Corses
        /// </summary>
        /// <returns>A list of all courses we have in database</returns>
        [ProducesResponseType(StatusCodes.Status200OK ,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpGet("getAllCoursesStudent")]
        public List<Course> GetAllCourses() => dal.GetAllCursuri();
    }
}
