namespace FoodSafeMontreal.Application.Establishments;

public sealed record FoodEstablishmentSummary(
    int ExternalBusinessId,
    string Name,
    string Address,
    string City,
    string Category);
