using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactProjectNET6.Api.Models;
using ReactProjectNET6.Api.Service;

namespace ReactProjectNET6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _VehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _VehiculoService = vehiculoService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(
                _VehiculoService.GetAll()
                );

        }


        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(
                   _VehiculoService.Get
                   (Id));

        }

        [HttpPost]
        public IActionResult Post([FromBody] Vehiculo vehiculo)
        {
            return Ok(
                _VehiculoService.Add(vehiculo)
                );
        }

        //[HttpPut("{idVehiculo}")]
        //public IActionResult Put(int idVehiculo, [FromBody] Vehiculo vehiculo)
        //{
        //    return Ok(
        //        _VehiculoService.Update(idVehiculo, vehiculo)
        //        );
        //}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _VehiculoService.Remove(id)
                );
        }
    }
}
