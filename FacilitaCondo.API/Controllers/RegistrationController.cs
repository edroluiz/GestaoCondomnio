using FacilitaCondo.Application.Interfaces;
using FacilitaCondo.Application.Interfaces.RegisterTenant;
using FacilitaCondo.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FacilitaCondo.API.Controllers
{
    [ApiController]
    [Route("registration")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class RegistrationController : ControllerBase
    {
        [HttpPost("v1/condominium")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "")]
        public async Task<ActionResult> RegisterCondominium(RegisterCondominiumRequest request, [FromServices] IRegisterCondominiumUseCase useCase)
        {
            return Ok(await useCase.Execute(request));
        }

        [HttpPost("v1/condominium-manager")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "")]
        public async Task<ActionResult> RegisterCondominiumManager(RegisterCondominiumManagerRequest request, [FromServices] IRegisterCondominiumManagerUseCase useCase)
        {
            return Ok(await useCase.Execute(request));
        }

        [HttpPost("v1/owner")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "")]
        public async Task<ActionResult> RegisterOwner(RegisterOwnerRequest request, [FromServices] IRegisterOwnerUseCase useCase)
        {
            return Ok(await useCase.Execute(request));
        }

        [HttpPost("v1/tenant")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "")]
        public async Task<ActionResult> RegisterTenant(RegisterTenantRequest request, [FromServices] IRegisterTenantUseCase useCase)
        {
            return Ok(await useCase.Execute(request));
        }
    }
}
