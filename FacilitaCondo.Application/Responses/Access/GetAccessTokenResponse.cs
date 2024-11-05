using FacilitaCondo.Domain.Entities;
using Refit;

namespace FacilitaCondo.Application.Responses
{
    public class GetAccessTokenResponse
    {
        [AliasAs("access_token")]
        public string access_token { get; set; }

        [AliasAs("expires_in")]
        public int expires_in { get; set; }

        //[AliasAs("refresh_token")]
        //public string refresh_token { get; set; }

        public CondominiumManagerResponse CondominiumManager { get; set; }
        public OwnerResponse Owner { get; set; }
        public TenantResponse Tenant { get; set; }
    }
}
