using Data;
using Microsoft.AspNetCore.Mvc;
using Proiect.Dtos;
using Proiect.Utils;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public AddressController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Update Or Create Address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateAddress"></param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdateCreateStudentAddress([FromRoute] int id, [FromBody] AddressTuUpdateDto updateAddress)
        {
            if (dal.UpdateOrCreateStudentAddres(id, updateAddress.ToEntity()))
            {
                return Created("Success", null);
            }
            return Ok();

        }

    }
}
