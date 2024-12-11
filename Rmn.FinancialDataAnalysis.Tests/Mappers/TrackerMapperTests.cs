using FluentAssertions;
using Rmn.FinancialDataAnalysis.Business.Trackers.Models;
using Rmn.FinancialDataAnalysis.Dtos;
using Rmn.FinancialDataAnalysis.Mappers;
using Rmn.FinancialDataAnalysis.Shared.Tests.Builders;

namespace Rmn.FinancialDataAnalysis.Tests.Mappers;

public class TrackerMapperTests
{
    private TrackerMapper _mapper;
    private TrackerDto _trackerDtos;
    private Tracker _tracker;

    [SetUp]
    public void Setup()
    {
        _mapper = new TrackerMapper();

        var trackerBuilder = GetTrackerBuilder();
        _trackerDtos = trackerBuilder.BuildTrackerDto();
        _tracker = trackerBuilder.BuildTrackerEntity();
    }

    [Test]
    public void MapDtoToEntity()
    {
        var result = _mapper.ToEntity(_trackerDtos);

        result.Should().BeEquivalentTo(_tracker);
    }

    [Test]
    public void MapEntityToDto()
    {
        var result = _mapper.ToDto(_tracker);

        result.Should().BeEquivalentTo(_trackerDtos);
    }

    [Test]
    public void MapEntityListToDtoList()
    {
        var result = _mapper.ToDto(new List<Tracker>() { _tracker }.AsEnumerable());

        result.Should().BeEquivalentTo(new List<TrackerDto>() { _trackerDtos });
    }

    private static TrackerBuilder GetTrackerBuilder()
    {
        return new TrackerBuilder()
            .WithName("SP500")
            .WithDescription("Description SP500")
            .WithExpansionTracker("INXSP5");
    }
}
