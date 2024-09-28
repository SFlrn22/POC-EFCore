using EFCorePOC.Application.Contracts;
using EFCorePOC.Domain;

namespace EFCorePOC.Application.Implementations;

public class SubscriberService(ISubscriberRepository subscriberRepository) : ISubscriberService
{
    public IEnumerable<Subscriber> GetSubscribers(FilterModel filterModel)
    {
        var result = subscriberRepository.GetSubscribers(filterModel);
        return result;
    }
}
