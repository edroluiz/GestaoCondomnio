namespace FacilitaCondo.Application.Interfaces
{
    public interface IGetValidTemporaryTokenUseCase
    {
        Task<bool> Execute(string token);
    }
}
