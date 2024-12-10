using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Rmn.FinancialDataAnalysis.Dtos;
using Rmn.FinancialDataAnalysis.Repositories.Trackers;
using Rmn.FinancialDataAnalysis.Shared.Tests.Builders;
using Rmn.FinancialDataAnalysis.Shared.Tests.WebHosts;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Rmn.FinancialDataAnalysis.Tests.Controllers;

public class TrackerControllerTests : WebHostTest
{

    [Test]
    public async Task GetAll_Tracker_Ibex35()
    {
        var trackerBuilder = await GivenTracker(TrackerContext);
        var expected = trackerBuilder.BuildTrackerDto();

        using var server = new TestServer(WebHostBuilder);
        using var client = server.CreateClient();
        var result = await client.GetFromJsonAsync<IEnumerable<TrackerDto>>("/api/Trackers/GetTrackers");
        
        result.Should().ContainEquivalentOf(expected);
    }
    
    [Test]
    public async Task GetTrackerById()
    {
        var trackerBuilder = await GivenTracker(TrackerContext);
        var expected = trackerBuilder.BuildTrackerDto();

        using var server = new TestServer(WebHostBuilder);
        using var client = server.CreateClient();
        
        var result = await client.GetFromJsonAsync<TrackerDto>($"/api/Trackers/Get?trackerId={expected.Id}");
        result.Should().BeEquivalentTo(expected);
    }


    private async Task<TrackerBuilder> GivenTracker(TrackerContext context)
    {
        var trackerBuilder = CreateTrackerBuilder();
        context.Trackers.Add(trackerBuilder.BuildTrackerEntity());
        await context.SaveChangesAsync();
        return trackerBuilder;
    }

    private static TrackerBuilder CreateTrackerBuilder()
    {
        var trackerBuilder = new TrackerBuilder()
            .WithName("IBEX")
            .WithDescription("SomeDescription")
            .WithExpansionTracker("IB.I");
        return trackerBuilder;
    }
}
