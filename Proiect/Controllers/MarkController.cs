using Data;
using Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Dtos;
using Proiect.Utils;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public MarkController(IDataAccessLayerService dal)
        {

            this.dal = dal;

        }
        /// <summary>
        /// Create Mark for Student
        /// </summary>
        /// <param name="mark"></param>
        [HttpPost("addMarkForAStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarkToCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public void AddMarkForStudent([FromBody] MarkToCreateDto mark) =>
            dal.AddMark(mark.Grade, mark.CourseId , mark.StudentId);

        /// <summary>
        /// Get All Marks for a student
        /// </summary>
        /// <returns>A list of  marks for a student from db for all courses that he have</returns>
        [HttpGet("getAllMarks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public List<Mark> GetAllMarks() => dal.GetAllNotes();

        /// <summary>
        /// Get Average Per Subject
        /// </summary>
        /// <param name="studentIdAverage">studentId</param>
        /// <param name="studentIdAverage">courseId</param>
        /// <returns>Return student average per one subject</returns>
        [HttpGet("averagePerSubject")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarksAverageDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<IEnumerable<MarksAverageDto>> GetAveragePerSbj(int studentId,int courseId)
        {
            var averageList = dal.GetAverage(studentId, courseId);

            if (averageList != null && averageList.Any())
            {
                var average = averageList.First().AverageTotal;

                var averageDtoList = new List<MarksAverageDto>
                {
            new MarksAverageDto
            {
                AverageTotal = average,
                CourseId = courseId,
                StudentId = studentId
            }
                };

                return Ok(averageDtoList);
            }
            else
            {
                return NotFound("No data found");
            }
        }

       

    }
}
