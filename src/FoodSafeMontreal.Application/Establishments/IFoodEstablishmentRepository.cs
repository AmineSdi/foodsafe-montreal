using FoodSafeMontreal.Domain.Establishments;

namespace FoodSafeMontreal.Application.Establishments;

public interface IFoodEstablishmentRepository
{
    Task<IReadOnlyList<FoodEstablishment>> SearchAsync(
        string? searchTerm,
        CancellationToken cancellationToken = default);
}
