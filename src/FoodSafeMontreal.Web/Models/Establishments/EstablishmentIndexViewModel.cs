namespace FoodSafeMontreal.Web.Models.Establishments;

public sealed record EstablishmentIndexViewModel(
    string? SearchTerm,
    IReadOnlyList<EstablishmentListItemViewModel> Establishments);
