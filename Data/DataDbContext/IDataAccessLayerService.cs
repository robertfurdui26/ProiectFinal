using Data.Models;

namespace Data
{
    public interface IDataAccessLayerService
    {
        void Seed();
        void AddMark(int grade, int courseid, int studentId);
        void DeleteStudent(int studentId);
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetStudentByAverageOrder();
        Student CreateStudent(Student student);
        Student Update(Student studentToUpdate);
        Student GetStudentById(int id);
        Address GetStudentAddress(int studentId);
        bool UpdateOrCreateStudentAddres(int studentId, Address nouaAdresa);
        Course AddCourse(string nameCourse);
        List<Course> GetAllCursuri();
        List<Mark> GetAllNotes();
        List<Mark> GetAverage(int studentId, int courseId);

    }
}