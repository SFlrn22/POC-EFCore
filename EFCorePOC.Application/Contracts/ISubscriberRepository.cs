using EFCorePOC.Domain;

namespace EFCorePOC.Application.Contracts;
public interface ISubscriberRepository
{
    IEnumerable<Subscriber> GetSubscribers(FilterModel filterModel);
}
