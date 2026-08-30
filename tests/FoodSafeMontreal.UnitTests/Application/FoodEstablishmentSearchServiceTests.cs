using FoodSafeMontreal.Application.Establishments;
using FoodSafeMontreal.Domain.Establishments;

namespace FoodSafeMontreal.UnitTests.Application;

public sealed class FoodEstablishmentSearchServiceTests
{
    [Fact]
    public async Task SearchAsync_TrimsSearchTermAndMapsResult()
    {
        var repository = new RecordingRepository(
            new FoodEstablishment(
                42,
                "Café Test",
                "10 rue Exemple",
                "Montréal",
                "Café"));
        var service = new FoodEstablishmentSearchService(repository);

        var result = await service.SearchAsync("  café  ");

        Assert.Equal("café", repository.SearchTerm);
        var establishment = Assert.Single(result);
        Assert.Equal(42, establishment.ExternalBusinessId);
        Assert.Equal("Café Test", establishment.Name);
    }

    private sealed class RecordingRepository(params FoodEstablishment[] establishments)
        : IFoodEstablishmentRepository
    {
        public string? SearchTerm { get; private set; }

        public Task<IReadOnlyList<FoodEstablishment>> SearchAsync(
            string? searchTerm,
            CancellationToken cancellationToken = default)
        {
            SearchTerm = searchTerm;
            return Task.FromResult<IReadOnlyList<FoodEstablishment>>(establishments);
        }
    }
}
