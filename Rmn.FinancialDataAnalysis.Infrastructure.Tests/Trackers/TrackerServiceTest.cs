using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Rmn.FinancialDataAnalysis.Business.Trackers;
using Rmn.FinancialDataAnalysis.Business.Trackers.Models;
using Rmn.FinancialDataAnalysis.Infrastructure.Trackers;
using Rmn.FinancialDataAnalysis.Shared.Tests.Builders;

namespace Rmn.FinancialDataAnalysis.Infrastructure.Tests.Trackers;

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
        var result = await _service.GetAll();

        result.Should().BeEmpty();
    }

    [Test]
    public async Task ReturnAll()
    {
        var tracker = GivenTrackerBuilder();
        _repository.GetAll().Returns(new List<Tracker>() { tracker });

        var result = await _service.GetAll();

        result.Should().HaveCount(1);
        result.Should().ContainEquivalentOf(tracker);
    }

    [Test]
    public async Task ReturnTrackerById()
    {
        var tracker = GivenTrackerBuilder();
        _repository.Get(tracker.Id).Returns(tracker);

        var result = await _service.Get(tracker.Id);

        result.Should().BeEquivalentTo(tracker);
    }

    [Test]
    public async Task CreateTracker()
    {
        var tracker = GivenTrackerBuilder();

        _repository.Create("Name", "Descripton", "Tracker").Returns(tracker);

        var result = await _service.Create("Name", "Descripton", "Tracker");
        result.Should().Be(tracker.Id);
    }

    [Test]
    public async Task DeleteTrackerByID()
    {
        var tracker = GivenTrackerBuilder();
        _repository.Delete(tracker.Id).Returns(true);

        var result = await _service.Delete(tracker.Id);

        result.Should().BeTrue();
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