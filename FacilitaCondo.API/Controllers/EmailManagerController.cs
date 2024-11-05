using FacilitaCondo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FacilitaCondo.API.Controllers
{
    [ApiController]
    [Route("email-manager")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class EmailManagerController : ControllerBase
    {
        [HttpPost("v1/send-temporary-token-to-email")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "")]
        public async Task<ActionResult> SendTemporaryTokenToEmail(string email, [FromServices] ISendTemporaryTokenToEmailUseCase useCase)
        {
            return Ok(await useCase.Execute(email));
        }

        [HttpGet("v1/get-valid-temporary-token")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "")]
        public async Task<ActionResult> GetValidTemporaryToken(string token, [FromServices] IGetValidTemporaryTokenUseCase useCase)
        {
            return Ok(await useCase.Execute(token));
        } 
    }
}
