using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Rmn.FinancialDataAnalysis.Business.Trackers;
using Rmn.FinancialDataAnalysis.Services.Trackers;
using Rmn.FinancialDataAnalysis.Shared.Tests.Builders;

namespace Rmn.FinancialDataAnalysis.Services.Tests.Services;

public class TrackerServiceTest
{
    private ITrackerRepository _repository;
    private TrackerService _service;

    [SetUp]
    public void Setup()
    {
        _repository = Substitute.For<ITrackerRepository>();
        _service = new TrackerService(_repository);
    }

    [Test]
    public async Task ReturnEmpty()
    {
        var result = await _service.GetTrackers();

        result.Should().BeEmpty();
    }

    [Test]
    public async Task ReturnAll()
    {
        var tracker = GivenTrackerBuilder();
        _repository.GetTrackers().Returns(new List<Tracker>() { tracker });

        var result = await _service.GetTrackers();

        result.Should().HaveCount(1);
        result.Should().ContainEquivalentOf(tracker);
    }

    [Test]
    public async Task ReturnTrackerById()
    {
        var tracker = GivenTrackerBuilder();
        _repository.GetTrackerById(tracker.Id).Returns(tracker);

        var result = await _service.GetTrackersById(tracker.Id);

        result.Should().BeEquivalentTo(tracker);
    }
    
    private static Tracker GivenTrackerBuilder()
    {
        var tracker = new TrackerBuilder()
            .WithName("Name")
            .WithDescription("Description")
            .WithExpansionTracker("IB.I")
            .BuildTrackerEntity();
        return tracker;
    }
}