namespace FacilitaCondo.Application.Interfaces
{
    public interface ISendTemporaryTokenToEmailUseCase
    {
        Task<bool> Execute(string email);
    }
}
