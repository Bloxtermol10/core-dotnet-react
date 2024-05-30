using Microsoft.AspNetCore.Mvc;
using Core.Infraestructure;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/BasicasLista")]
    public class ComunesController : ControllerBase
    {
        private readonly ComunesDao _comunesDao;

        public ComunesController(ComunesDao comunesDao)
        {
            _comunesDao = comunesDao;
        }

        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            try
            {
                var lista = _comunesDao.ObtenerLista(nombre);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }  
        [HttpGet("{nombre}/{idFiltro}")]
        public IActionResult Get(string nombre, string idFiltro)
        {
            try
            {
                var lista = _comunesDao.ObtenerLista(nombre, idFiltro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("whitFilters/{nombre}")]
        public IActionResult Get(string nombre, [FromQuery] string[] filtros)
        {
            try
            {
                var lista = _comunesDao.ObtenerLista(nombre, filtros);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
