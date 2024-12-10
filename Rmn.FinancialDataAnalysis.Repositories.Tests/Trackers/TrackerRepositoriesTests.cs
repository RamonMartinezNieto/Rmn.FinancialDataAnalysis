using FluentAssertions;
using NUnit.Framework;
using Rmn.FinancialDataAnalysis.Business.Trackers;
using Rmn.FinancialDataAnalysis.Migrations;
using Rmn.FinancialDataAnalysis.Repositories.Trackers;
using Rmn.FinancialDataAnalysis.Shared.Tests.Builders;
using Rmn.FinancialDataAnalysis.Shared.Tests.DatabaseContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmn.FinancialDataAnalysis.Repositories.Tests.Trackers;

public class TrackerRepositoriesTests : MemoryDatabaseTrackerContextTests
{
    private TrackerRepository _repository;

    [SetUp]
    public void Setup()
    {
        _repository = new TrackerRepository(TrackerContext);
    }

    [Test]
    public async Task GetAllTrackers_WhenEmpty()
    {
        IEnumerable<Tracker> result = await _repository.GetTrackers();

        result.Should().BeEmpty();
    }

    [Test]
    public async Task GetAllTrackers_WhenExists()
    {
        var tracker = await GivenTracker(TrackerContext);

        IEnumerable<Tracker> result = await _repository.GetTrackers();

        result.Should().HaveCount(1);
        result.Should().ContainEquivalentOf(tracker);
    }

    private async Task<Tracker> GivenTracker(TrackerContext context)
    {
        var tracker = new TrackerBuilder()
            .WithName("IBEX")
            .WithDescription("SomeDescription")
            .WithExpansionTracker("IB.I")
            .BuildTrackerEntity();

        context.Trackers.Add(tracker);
        await context.SaveChangesAsync();
        return tracker;
    }
}