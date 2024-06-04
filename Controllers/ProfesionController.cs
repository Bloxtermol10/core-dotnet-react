using Core.ORM;
using Core.ORM.Helpers;
using Core.ORM.Entities;
using Microsoft.AspNetCore.Mvc;


using System.Collections.Generic;
using System.Linq;
using static Core.ORM.Helpers.ValidationHelper;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionController : ControllerBase
    {
        private readonly DbContext _context;

        public ProfesionController(DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Profesion>> GetProfesiones()
        {
            var profesiones = _context.Set<Profesion>().ToList();
            return Ok(profesiones);
        }

        [HttpGet("{id}")]
        public ActionResult<Profesion> GetProfesion(int id)
        {
            var profesion = _context.Set<Profesion>().ToList().FirstOrDefault(p => p.idProfesion == id);
            if (profesion == null)
            {
                return NotFound();
            }
            return Ok(profesion);
        }

        [HttpPost]
        public ActionResult<Profesion> CreateProfesion([FromBody] Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validación de propiedades adicional para el método Add
            if (!ValidationHelper.ValidateProperties(ActionType.Update,
                profesion, ModelState,
                nameof(profesion.usuarioCrea)))
            {
                return BadRequest(ModelState);
            }

            profesion.fechaCrea = DateTime.Now; // Assuming FechaCrea is set to current date-time on creation
            _context.Set<Profesion>().Add(profesion);
            return CreatedAtAction(nameof(GetProfesion), new { id = profesion.idProfesion }, profesion);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProfesion(int id, [FromBody] Profesion profesion)
        {
            var existingProfesion = _context.Set<Profesion>().ToList().FirstOrDefault(p => p.idProfesion == id);
            if (existingProfesion == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // Validación adicional para el método Update
            if (!ValidationHelper.ValidateProperties(ActionType.Update, 
                profesion, ModelState,
                nameof(profesion.usuarioModifica)
                ))
            {
                return BadRequest(ModelState);
            }

            existingProfesion.nomProfesion = profesion.nomProfesion;
            existingProfesion.usuarioModifica = profesion.usuarioModifica;
            existingProfesion.fechaModifica = DateTime.Now; // Assuming FechaModifica is set to current date-time on update

            _context.Set<Profesion>().Update(existingProfesion);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProfesion(int id)
        {
            var profesion = _context.Set<Profesion>().ToList().FirstOrDefault(p => p.idProfesion == id);
            if (profesion == null)
            {
                return NotFound();
            }

            _context.Set<Profesion>().Remove(profesion);
            return NoContent();
        }
    }
}
