using FacilitaCondo.Application.Responses;
using FacilitaCondo.Domain.Entities;
using FacilitaCondo.Domain.Repository;
using FacilitaCondo.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FacilitaCondo.Application.Queries
{
    public class GetAccessTokenQueryHandler : IRequestHandler<GetAccessTokenQuery, GetAccessTokenResponse>
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public GetAccessTokenQueryHandler(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<GetAccessTokenResponse> Handle(GetAccessTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByUsernameAndPassword(request.Email, request.Password);

            if (user == null)
            {
                throw new DomainException("Invalid credentials.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            CondominiumManagerResponse condominiumManagerResponse = null;
            OwnerResponse ownerResponse = null;
            TenantResponse tenantResponse = null;

            if (user is CondominiumManager cm)
            {
                condominiumManagerResponse = new CondominiumManagerResponse
                {
                    Id = cm.Id,
                    CondominiumId = cm.CondominiumId,
                    Name = cm.Name,
                    Cpf = cm.Cpf,
                    Email = cm.Email,
                    IsResident = cm.IsResident,
                    ResidenceType = cm.ResidenceType,
                    ApartmentBlock = cm.ApartmentBlock,
                    ResidenceNumber = cm.ResidenceNumber,
                    CreatedDate = cm.CreatedDate,
                    ModifiedDate = cm.ModifiedDate
                };
            }
            else if (user is Owner owner)
            {
                ownerResponse = new OwnerResponse
                {
                    Id = owner.Id,
                    CondominiumId = owner.CondominiumId,
                    CondominiumManagerId = owner.CondominiumManagerId,
                    Name = owner.Name,
                    Cpf = owner.Cpf,
                    Email = owner.Email,
                    ResidenceType = owner.ResidenceType,
                    ApartmentBlock = owner.ApartmentBlock,
                    ResidenceNumber = owner.ResidenceNumber,
                    HasTenant = owner.HasTenant,
                    TenantEmail = owner.TenantEmail
                };
            }
            else if (user is Tenant tenant)
            {
                tenantResponse = new TenantResponse
                {
                    Id = tenant.Id,
                    CondominiumId = tenant.CondominiumId,
                    OwnerId = tenant.OwnerId,
                    Name = tenant.Name,
                    Cpf = tenant.Cpf,
                    Email = tenant.Email
                };
            }

            return new GetAccessTokenResponse
            {
                access_token = tokenHandler.WriteToken(token),
                expires_in = 3600, // Tempo de expiração em segundos (1 hora)
                CondominiumManager = condominiumManagerResponse,
                Owner = ownerResponse,
                Tenant = tenantResponse
            };
        }
    }
}
