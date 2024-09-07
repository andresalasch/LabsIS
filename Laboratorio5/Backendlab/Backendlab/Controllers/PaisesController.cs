using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Backendlab.Models;
using Backendlab.Handlers;

namespace Backendlab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly PaisesHandler _paisesHandler;
        
        public PaisesController()
        {
            _paisesHandler = new PaisesHandler();
        }

        [HttpGet] public List<PaisModel> get()
        {
            var paises = _paisesHandler.ObtenerPaises();
            return paises;
        }
    }
}
