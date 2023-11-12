using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Dto;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;

        public SeedController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// SeedDatabase
        /// </summary>
        /// 
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public void Seed() => dal.Seed();


    }
}
