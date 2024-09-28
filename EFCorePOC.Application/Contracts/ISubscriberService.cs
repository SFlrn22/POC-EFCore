using EFCorePOC.Domain;

namespace EFCorePOC.Application.Contracts;
public interface ISubscriberService
{
    IEnumerable<Subscriber> GetSubscribers(FilterModel filterModel);
}
