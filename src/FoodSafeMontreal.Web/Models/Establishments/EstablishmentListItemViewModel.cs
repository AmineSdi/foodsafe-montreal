namespace FoodSafeMontreal.Web.Models.Establishments;

public sealed record EstablishmentListItemViewModel(
    int ExternalBusinessId,
    string Name,
    string Address,
    string City,
    string Category);
