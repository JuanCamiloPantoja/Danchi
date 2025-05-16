using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IReservasRepository _repository;

        public ReservasController(IReservasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetReservas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRegistro()
        {
            var response = await _repository.GetReservas();
            return Ok(response);
        }

        [HttpPost("PostReservas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostReservas([FromBody] Reservas reservas)
        {
            try
            {
                var response = await _repository.PostReservas(reservas);
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

        [HttpPut("PutReservas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutReservas(int id, [FromBody] Reservas reservas)
        {
            if (id != reservas.IdReservas)
            {
                return BadRequest("El ID de la reserva no coincide con el proporcionado.");
            }
            try
            {
                var response = await _repository.PutReservas(reservas);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Reserva no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteReservas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReservas(int id)
        {
            try
            {
                var response = await _repository.DeleteReservas(id);
                if (response)
                    return Ok("Eliminado correctamente");
                else
                    return NotFound("Reserva no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

