using Aplication.Services;
using Infraestructure.data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimerProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaServices _service;
        public CategoriaController(CategoriaServices service)
        {
            _service = service;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Categorium pCategoria)
        {
            _service.Add(pCategoria);
            return Ok(pCategoria);
        }
        [HttpPut]
        public ActionResult Put([FromBody] Categorium pCategoria)
        {
            _service.Update(pCategoria);
            return Ok(pCategoria);
        }


    }
}
