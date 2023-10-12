using PAC.Domain;

namespace PAC.IDataAccess;

public interface IStudentsRepository<T> where T : class
{
    IEnumerable<Student> GetStudents();
    IEnumerable<Student> GetStudents(int edad);
    Student GetStudentById(int id);
    void InsertStudents(Student? student);

}

