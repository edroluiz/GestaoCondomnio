using MediatR;

namespace FacilitaCondo.API.Extensions
{
    public static class MediatrExtension
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
