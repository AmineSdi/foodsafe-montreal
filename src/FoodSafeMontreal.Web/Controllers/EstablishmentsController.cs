using FoodSafeMontreal.Application.Establishments;
using FoodSafeMontreal.Web.Models.Establishments;
using Microsoft.AspNetCore.Mvc;

namespace FoodSafeMontreal.Web.Controllers;

public sealed class EstablishmentsController(
    FoodEstablishmentSearchService searchService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(
        string? q,
        CancellationToken cancellationToken)
    {
        var establishments = await searchService.SearchAsync(q, cancellationToken);

        var model = new EstablishmentIndexViewModel(
            q,
            establishments
                .Select(establishment => new EstablishmentListItemViewModel(
                    establishment.ExternalBusinessId,
                    establishment.Name,
                    establishment.Address,
                    establishment.City,
                    establishment.Category))
                .ToArray());

        return View(model);
    }
}
