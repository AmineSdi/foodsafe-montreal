namespace FoodSafeMontreal.Application.Establishments;

public sealed class FoodEstablishmentSearchService(
    IFoodEstablishmentRepository repository)
{
    public async Task<IReadOnlyList<FoodEstablishmentSummary>> SearchAsync(
        string? searchTerm,
        CancellationToken cancellationToken = default)
    {
        var normalizedSearchTerm = string.IsNullOrWhiteSpace(searchTerm)
            ? null
            : searchTerm.Trim();

        var establishments = await repository.SearchAsync(
            normalizedSearchTerm,
            cancellationToken);

        return establishments
            .Select(establishment => new FoodEstablishmentSummary(
                establishment.ExternalBusinessId,
                establishment.Name,
                establishment.Address,
                establishment.City,
                establishment.Category))
            .ToArray();
    }
}
