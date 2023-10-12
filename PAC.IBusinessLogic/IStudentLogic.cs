namespace PAC.IBusinessLogic;
using PAC.Domain;

public interface IStudentLogic
{
    IEnumerable<Student> GetStudents();
    IEnumerable<Student> GetStudents(int edad);
    Student GetStudentById(int id);
    void InsertStudents(Student? student);

}

