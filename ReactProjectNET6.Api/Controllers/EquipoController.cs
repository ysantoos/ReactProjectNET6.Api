using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactProjectNET6.Api.Models;
using ReactProjectNET6.Api.Service;

namespace ReactProjectNET6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquipoService _EquipoService;

        public EquipoController(IEquipoService equipoService)
        {
            _EquipoService = equipoService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(
                _EquipoService.GetAll()
                );

        }


        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(
                   _EquipoService.Get
                   (Id));

        }
    }
}
