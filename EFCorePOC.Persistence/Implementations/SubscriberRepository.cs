using EFCorePOC.Application.Contracts;
using EFCorePOC.Domain;

namespace EFCorePOC.Persistence.Implementations;

public class SubscriberRepository(ModelContext context) : ISubscriberRepository
{
    public IEnumerable<Subscriber> GetSubscribers(FilterModel model)
    {
        var query = context.Subscribers.AsQueryable();

        if (model.Filters.Any())
        {
            foreach (var filter in model.Filters)
            {
                query = filter.Value.Relation.ToLower() switch
                {
                    "equals" => filter.Key.ToLower() switch
                    {
                        "name" => query.Where(q => q.Name.Equals(filter.Value.FilterValue)),
                        "subscribed" => query.Where(q => q.Subscribed.Equals(filter.Value.FilterValue)),
                        _ => throw new ArgumentException("Invalid filter name.")
                    },
                    "contains" => filter.Key.ToLower() switch
                    {
                        "name" => query.Where(q => q.Name.Contains(filter.Value.FilterValue)),
                        "subscribed" => query.Where(q => q.Subscribed.Contains(filter.Value.FilterValue)),
                        _ => throw new ArgumentException("Invalid filter name.")
                    },
                    _ => throw new ArgumentException("Invalid relation type.")
                };
            }
        }

        query = query.Skip((model.PageNumber - 1) * model.PageSize).Take(model.PageSize);

        return query;
    }
}
