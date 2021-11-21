using AutoMapper;
using HomiePages.Application.Dtos.Equities;
using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.Domain.Enums;
using HomiePages.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HomiePages.Infrastructure.Services.EntityServices
{
    public class AuthCodeService : ServiceBaseHelper<AuthCode>, IAuthCodeService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;

        public AuthCodeService(IRepositoryWrapper repo, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(repo, repo.AuthCodes, httpContextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public bool AddAuthCode(string code)
        {
            var authCodeEntity = new AuthCode()
            {
                UserId = UserId,
                Code = code,
                Type = CodeType.AuthToken,
                Provider = AuthProvider.Strava
            };

            _repo.AuthCodes.Create(authCodeEntity);
            var res = _repo.SaveChanges();
            return res;
        }
    }
}
