using Microsoft.AspNetCore.Mvc;
using prueba.Models;
using prueba.servicio;

namespace prueba.Controllers
{
    [ApiController]
    [Route("controller")]
    public class Datos : ControllerBase
    {
        private readonly UsuarioServicio usuarioServicio;
        private readonly DireccionServicio direccionServicio;
        private readonly PostalCodeService postalCodeService;

        
        public Datos(UsuarioServicio UserServicio, DireccionServicio addressServicio, PostalCodeService codigoPostalServicio )
        {
            usuarioServicio = UserServicio;
            direccionServicio = addressServicio;
            postalCodeService = codigoPostalServicio;
            
        }

        [HttpGet("obtner-datos")]
        public async Task<IActionResult> obtenerUsuario()
        {
            try
            {
                var usuario = await usuarioServicio.ObtenerUsuarioDeUrl();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los datos del usuario: {ex.Message}");
            }
        }

        [HttpGet("DireccionesOrdenadas")]
        public async Task<IActionResult> GetDireccionesOrdenadas([FromQuery] string ord = "Address1", [FromQuery] bool ascending = true)
        {
            try
            {
                var usuario = await usuarioServicio.ObtenerUsuarioDeUrl();


                DireccionServicio.ordenar opcion;
                if (!Enum.TryParse(ord, true, out opcion))
                {
                    return BadRequest("Invalid sorting option. Available options are 'Address1' and 'CreationDate'.");
                }

                // Ordenamos las direcciones
                var direccionesOrdenadas = direccionServicio.SortAddresses(usuario.Address, opcion, ascending);

                return Ok(direccionesOrdenadas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"error: {ex.Message}");
            }
        }

        [HttpGet("BuscarPostalCode")]
        public async Task<IActionResult> buscarPostalCode([FromQuery] string postalCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(postalCode))
                {
                    return BadRequest("se necesita un PC.");
                }

                var usuario = await usuarioServicio.ObtenerUsuarioDeUrl();

                var codigoEncontrado = postalCodeService.BuscarPostalCode(usuario.Address, postalCode);

                if (codigoEncontrado == null || !codigoEncontrado.Any())
                {
                    return NotFound("no hay :( .");
                }

                return Ok(codigoEncontrado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"error: {ex.Message}");
            }
        }


    }
    
}
