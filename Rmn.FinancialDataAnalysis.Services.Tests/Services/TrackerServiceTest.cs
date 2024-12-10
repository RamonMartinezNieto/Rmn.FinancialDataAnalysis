using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Rmn.FinancialDataAnalysis.Business.Trackers;
using Rmn.FinancialDataAnalysis.Services.Trackers;
using Rmn.FinancialDataAnalysis.Shared.Tests.Builders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmn.FinancialDataAnalysis.Tests.Services;

public class TrackerServiceTest
{
    private ITrackerRepository _repository;
    private ITrackerService _service;

    [SetUp]
    public void Setup()
    {
        _repository = Substitute.For<ITrackerRepository>();
        _service = new TrackerService(_repository);
    }

    [Test]
    public async Task ReturnEmpty()
    {
        IEnumerable<Tracker> result = await _service.GetTrackers();

        result.Should().BeEmpty();
    }

    [Test]
    public async Task ReturnAll()
    {
        var tracker = new TrackerBuilder()
            .WithName("Name")
            .WithDescription("Description")
            .WithExpansionTracker("IB.I")
            .BuildTrackerEntity();

        _repository.GetTrackers().Returns(new List<Tracker>() { tracker });

        IEnumerable<Tracker> result = await _service.GetTrackers();

        result.Should().HaveCount(1);
        result.Should().ContainEquivalentOf(tracker);
    }
}