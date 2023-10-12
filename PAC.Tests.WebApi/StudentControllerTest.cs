namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    private Mock<IStudentLogic> mock;
    private StudentController api;
    private Student estudiante;
    private Student estudianteNulo;

    [TestInitialize]
    public void InitTest()
    {
        mock = new Mock<IStudentLogic>(MockBehavior.Strict);
        api = new StudentController(mock.Object);

        estudiante = new Student()
        {
            Id = 1,
            Name = "Reina"
        };

        estudianteNulo = null;
    }

    [TestMethod]
    public void PostStudentOk()
    {
        mock.Setup(x => x.InsertStudents(estudiante));
        var result = api.CrearEstudiante(estudiante);
        var objectResult = result as ObjectResult;
        var statusCode = objectResult.StatusCode;

        mock.VerifyAll();
        Assert.AreEqual(200, statusCode);
    }

    [ExpectedException(typeof(ArgumentException))]
    [TestMethod]
    public void PostStudentFail()
    {
        mock.Setup(x => x.InsertStudents(estudianteNulo)).Throws(new ArgumentException());
        var result = api.CrearEstudiante(estudianteNulo);
        var objectResult = result as ObjectResult;
        var statusCode = objectResult.StatusCode;

        mock.VerifyAll();
        Assert.AreEqual(400, statusCode);
    }

}
