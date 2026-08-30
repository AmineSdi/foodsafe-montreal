using FoodSafeMontreal.Application.Establishments;
using FoodSafeMontreal.Domain.Establishments;

namespace FoodSafeMontreal.Infrastructure.Establishments;

public sealed class InMemoryFoodEstablishmentRepository : IFoodEstablishmentRepository
{
    private static readonly IReadOnlyList<FoodEstablishment> Establishments =
    [
        new(
            10001,
            "Boulangerie du Marché",
            "100 rue du Marché",
            "Montréal",
            "Boulangerie",
            45.5088,
            -73.5540),
        new(
            10002,
            "Café du Canal",
            "250 rue du Canal",
            "Montréal",
            "Café",
            45.4728,
            -73.5740),
        new(
            10003,
            "Cuisine du Plateau",
            "75 avenue du Parc",
            "Montréal",
            "Restaurant",
            45.5200,
            -73.5900),
        new(
            10004,
            "Épicerie Centrale",
            "410 boulevard Central",
            "Montréal",
            "Épicerie",
            45.5410,
            -73.6250)
    ];

    public Task<IReadOnlyList<FoodEstablishment>> SearchAsync(
        string? searchTerm,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IEnumerable<FoodEstablishment> query = Establishments;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(establishment =>
                Contains(establishment.Name, searchTerm) ||
                Contains(establishment.Address, searchTerm) ||
                Contains(establishment.City, searchTerm) ||
                Contains(establishment.Category, searchTerm));
        }

        IReadOnlyList<FoodEstablishment> result = query
            .OrderBy(establishment => establishment.Name)
            .ToArray();

        return Task.FromResult(result);
    }

    private static bool Contains(string value, string searchTerm) =>
        value.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
}
