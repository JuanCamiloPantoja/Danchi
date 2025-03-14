using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroRepository _repository;

        public RegistroController(IRegistroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetRegistro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRegistro()
        {
            var response = await _repository.GetRegistro();
            return Ok(response);
        }

        [HttpPost("PostRegistro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostRegistroe([FromBody] Registro registro)
        {
            try
            {
                var response = await _repository.PostRegistro(registro);
                if (response == true)
                    return Ok("Insertado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutRegistro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutResidente(int id, [FromBody] Registro registro)
        {
            if (id != registro.IDRegistro)
            {
                return BadRequest("El ID del registro no coincide con el proporcionado.");
            }
            try
            {
                var response = await _repository.PutRegistro(registro);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Registro no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteRegistro/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteResidente(int id)
        {
            try
            {
                var response = await _repository.DeleteRegistro(id);
                if (response)
                    return Ok("Eliminado correctamente");
                else
                    return NotFound("Registro no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
