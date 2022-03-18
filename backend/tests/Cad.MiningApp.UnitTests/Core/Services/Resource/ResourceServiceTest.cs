using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Cad.MiningApp.Core.Enums;
using Cad.MiningApp.Core.Interfaces;
using Cad.MiningApp.Core.Services.Resource;
using NSubstitute;
using Xunit;

namespace Cad.MiningApp.UnitTests.Core.Services.Resource;

public class ResourceServiceTest
{
    private readonly IFixture _fixture;

    public ResourceServiceTest()
    {
        _fixture = new Fixture()
            .Customize(new AutoNSubstituteCustomization());
    }

    [Fact]
    public async Task GetMinedQuantityAsync_returns_expected_quantity()
    {
        var expectedQuantity = _fixture.Create<int>();

        var repository = _fixture.Freeze<IMiningLogsRepository>();
        repository.GetQuantityAsync(Arg.Any<ResourceType>())
            .Returns(expectedQuantity);

        var sut = _fixture.Create<ResourceService>();
        var actualQuantity = await sut.GetMinedQuantityAsync();

        Assert.Equal(expectedQuantity, actualQuantity);
    }
}