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
        var expected = await GivenTracker();

        using var server = new TestServer(WebHostBuilder);
        using var client = server.CreateClient();
        var result = await client.GetFromJsonAsync<IEnumerable<TrackerDto>>("/api/Trackers/GetTrackers");
        
        result.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public async Task GetTrackerById()
    {
        var expected = await GivenTracker();
        
        using var server = new TestServer(WebHostBuilder);
        using var client = server.CreateClient();
        
        var result = await client.GetFromJsonAsync<TrackerDto>($"/api/Trackers/Get?trackerId={expected.Id}");
        result.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public async Task CreateNewTracker()
    {
        var createTrackerDto = new CreateTrackerDto("New Tracker", "New Description", "some expansion");
        
        using var server = new TestServer(WebHostBuilder);
        using var client = server.CreateClient();
        
        var result = await client.PostAsync($"/api/Trackers/Create",
            new StringContent(JsonSerializer.Serialize(createTrackerDto), Encoding.UTF8, "application/json"));
        
        result.EnsureSuccessStatusCode();
        var idTracker = await result.Content.ReadFromJsonAsync<Guid>();

        var trackerSaved = await client.GetFromJsonAsync<TrackerDto>($"/api/Trackers/Get?trackerId={idTracker}");
        trackerSaved.ExpansionTracker.Should().BeEquivalentTo(createTrackerDto.ExpansionTracker);
        trackerSaved.Description.Should().BeEquivalentTo(createTrackerDto.Description);
        trackerSaved.Name.Should().BeEquivalentTo(createTrackerDto.Name);
    }

    private async Task<TrackerDto> GivenTracker()
    {
        var trackerBuilder = await CreateTracker(TrackerContext);
        return trackerBuilder.BuildTrackerDto();
    }
    
    private async Task<TrackerBuilder> CreateTracker(TrackerContext context)
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
