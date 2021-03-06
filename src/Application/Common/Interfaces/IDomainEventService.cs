using HomiePages.Domain.Common;
using System.Threading.Tasks;

namespace HomiePages.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
