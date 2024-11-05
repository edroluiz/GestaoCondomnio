using FacilitaCondo.Application.Interfaces;
using FacilitaCondo.Application.Requests;
using FacilitaCondo.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FacilitaCondo.API.Controllers
{
    [ApiController]
    [Route("access")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AccessController : ControllerBase
    {
        [HttpPost("v1/get-access-token")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(GetAccessTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get Access Token", Description = @"Get Access Token")]
        public async Task<ActionResult> GetAccessToken([FromBody] GetAccessTokenRequest request, [FromServices] IGetAccessTokenUseCase useCase)
        {
            return Ok(await useCase.Execute(request));
        }
    }
}
