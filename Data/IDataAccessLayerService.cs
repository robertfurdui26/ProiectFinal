using Data.Models;

namespace Data
{
    public interface IDataAccessLayerService
    {
        Student CreateStudent(Student student);
        void DeleteStudent(int studentId);
        IEnumerable<Student> GetAllStudents();
        Address GetStudentAddress(int studentId);
        Student GetStudentById(int id);
        void Seed();
        Student Update(Student studentToUpdate);
        bool UpdateOrCreateStudentAddres(int studentId, Address nouaAdresa);

        Course AddCourse(string nameCourse);

        List<Course> GetAllCursuri();
        void AddMark(int grade, int courseid, int studentId);
        List<Mark> GetAllNotes();
        List<Mark> GetAverage(int studentId, int courseId);
        IEnumerable<Student> GetStudentByAverageOrder();

    }
}