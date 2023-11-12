
using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public void AddMark(int grade, int courseId, int studentId)
        {
            if (!ctx.Students.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException($"Id Student invalid {studentId}");
            }

            if (!ctx.Coursess.Any(c => c.Id == courseId))
            {
                throw new InvalidIdException($"Id Curs invalid {courseId}");
            }

            ctx.Marks.Add(new Mark
            {
                Grade = grade,
                StudentId = studentId,
                CourseId = courseId,
                GradeTime = DateTime.Now
            });

            ctx.SaveChanges();
        }

        public List<Mark> GetAllNotes() => ctx.Marks.ToList();
        public List<Mark> GetAverage(int studentId, int courseId)
        {
            try
            {
                var student = ctx.Students.Include(s => s.Marks).FirstOrDefault(s => s.Id == studentId);

                if (student != null)
                {
                    var noteList = student.Marks.Where(n => n.CourseId == courseId).ToList();

                    if (noteList.Any())
                    {
                        var average = noteList.Average(n => n.Grade);
                        noteList.ForEach(n => n.AverageTotal = average);
                       return noteList;
                    }
                    else
                    {
                        return new List<Mark>();
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Eroare la obținerea mediei: {ex.Message}");
                throw;
            }
        }

    }
}
