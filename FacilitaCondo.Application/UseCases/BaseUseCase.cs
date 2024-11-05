using MediatR;

namespace FacilitaCondo.Application.UseCases
{
    public abstract class BaseUseCase
    {
        protected readonly IMediator mediator;

        public BaseUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
