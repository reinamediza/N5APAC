using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic servicioEstudiante;

        public StudentController(IStudentLogic servicioEstudiante)
        {
            this.servicioEstudiante = servicioEstudiante;
        }

        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPost]
        public IActionResult CrearEstudiante([FromBody] Student estudiante )
        {
            servicioEstudiante.InsertStudents(estudiante);
            return Ok("Estudiante creado con exito");
        }

        [HttpGet]
        public IActionResult ObtenerEstudiantes([FromQuery] int? edad)
        {
            if (edad == null || edad == 0)
            {
                return Ok(servicioEstudiante.GetStudents());
            }else
            {
                return Ok(servicioEstudiante.GetStudents((int)edad));
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerEstudiante([FromRoute] int id)
        {
            return Ok(servicioEstudiante.GetStudentById(id));
        }

    }
}
