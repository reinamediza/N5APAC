Para que el controlador de estudiante use la logica de estudiante sin necesidad de hacer un new student 
o no usar directamente StudentLogic se utiliza inyeccion de dependencia de la siguiente forma:
 
Defino como privada la interfaz IStudentLogic y la agrego por parametros en el constructor de la clase del controlador 
de forma que solo accedo a los metodos de StudentLogic que estan definidos en la interfaz IStudentLogic
y no directamente a StudentLogic o a Student.
De esta forma tampoco acceso a DataAccess directamente ya que eso lo hace StudentLogic a traves de la interfaz IDataAccess.


private readonly IStudentLogic servicioEstudiante;

public StudentController(IStudentLogic servicioEstudiante)
{
    this.servicioEstudiante = servicioEstudiante;
}


