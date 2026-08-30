namespace FoodSafeMontreal.Domain.Establishments;

public sealed class FoodEstablishment
{
    private FoodEstablishment()
    {
        // Reserved for future persistence tooling.
    }

    public FoodEstablishment(
        int externalBusinessId,
        string name,
        string address,
        string city,
        string category,
        double? latitude = null,
        double? longitude = null)
    {
        if (externalBusinessId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(externalBusinessId),
                "The external business identifier must be positive.");
        }

        ExternalBusinessId = externalBusinessId;
        Name = RequiredText(name, nameof(name));
        Address = RequiredText(address, nameof(address));
        City = RequiredText(city, nameof(city));
        Category = RequiredText(category, nameof(category));
        Latitude = latitude;
        Longitude = longitude;
    }

    public int Id { get; private set; }

    public int ExternalBusinessId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Address { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    public string Category { get; private set; } = string.Empty;

    public double? Latitude { get; private set; }

    public double? Longitude { get; private set; }

    private static string RequiredText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("A value is required.", parameterName);
        }

        return value.Trim();
    }
}
