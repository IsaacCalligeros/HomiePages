using HomiePages.Domain.Entities;

namespace HomiePages.Application.ServiceInterfaces
{
    public interface IAuthCodeService : IServiceBaseHelper<AuthCode>
    {
        public bool AddAuthCode(string code);
    }
}
