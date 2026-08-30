using FoodSafeMontreal.Domain.Establishments;

namespace FoodSafeMontreal.UnitTests.Domain;

public sealed class FoodEstablishmentTests
{
    [Fact]
    public void Constructor_TrimsRequiredTextValues()
    {
        var establishment = new FoodEstablishment(
            42,
            "  Café Test  ",
            "  10 rue Exemple  ",
            "  Montréal  ",
            "  Café  ");

        Assert.Equal("Café Test", establishment.Name);
        Assert.Equal("10 rue Exemple", establishment.Address);
        Assert.Equal("Montréal", establishment.City);
        Assert.Equal("Café", establishment.Category);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_RejectsNonPositiveExternalId(int externalId)
    {
        var action = () => new FoodEstablishment(
            externalId,
            "Café Test",
            "10 rue Exemple",
            "Montréal",
            "Café");

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void Constructor_RejectsBlankName()
    {
        var action = () => new FoodEstablishment(
            42,
            "   ",
            "10 rue Exemple",
            "Montréal",
            "Café");

        Assert.Throws<ArgumentException>(action);
    }
}
