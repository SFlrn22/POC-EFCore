namespace EFCorePOC.Domain;

public partial class Subscriber
{
    public decimal Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Subscribed { get; set; } = string.Empty;
}
