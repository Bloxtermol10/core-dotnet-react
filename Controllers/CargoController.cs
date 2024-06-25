using Core.ORM;
using Core.ORM.Entities;
using Core.ORM.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static Core.ORM.Helpers.ValidationHelper;

namespace Core.ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly DbContext _context;

        public CargoController(DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cargo>> GetCargoes()
        {
            var Cargos = _context.Set<Cargo>().ToList();
            return Ok(Cargos);
        }

        [HttpGet("{id}")]
        public ActionResult<Cargo> GetCargo(int id)
        {
            var Cargo = _context.Set<Cargo>().ToList().FirstOrDefault(p => p.idCargo == id);
            if (Cargo == null)
            {
                return NotFound();
            }
            return Ok(Cargo);
        }

        [HttpPost]
        public ActionResult<Cargo> CreateCargo([FromBody] Cargo Cargo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validación de propiedades adicional para el método Add
            if (!ValidationHelper.ValidateProperties(ActionType.Update,
                Cargo, ModelState,
                nameof(Cargo.usuarioCrea)))
            {
                return BadRequest(ModelState);
            }

            Cargo.fechaCrea = DateTime.Now; // Assuming FechaCrea is set to current date-time on creation
            _context.Set<Cargo>().Add(Cargo);
            return CreatedAtAction(nameof(GetCargo), new { id = Cargo.idCargo }, Cargo);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCargo(int id, [FromBody] Cargo Cargo)
        {
            var existingCargo = _context.Set<Cargo>().ToList().FirstOrDefault(p => p.idCargo == id);
            if (existingCargo == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // Validación adicional para el método Update
            if (!ValidationHelper.ValidateProperties(ActionType.Update, 
                Cargo, ModelState,
                nameof(Cargo.usuarioModifica)
                ))
            {
                return BadRequest(ModelState);
            }

            existingCargo.nomCargo = Cargo.nomCargo;
            existingCargo.usuarioModifica = Cargo.usuarioModifica;
            existingCargo.fechaModifica = DateTime.Now; // Assuming FechaModifica is set to current date-time on update

            _context.Set<Cargo>().Update(existingCargo);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCargo(int id)
        {
            var Cargo = _context.Set<Cargo>().ToList().FirstOrDefault(p => p.idCargo == id);
            if (Cargo == null)
            {
                return NotFound();
            }

            _context.Set<Cargo>().Remove(Cargo);
            return NoContent();
        }
    }
}
