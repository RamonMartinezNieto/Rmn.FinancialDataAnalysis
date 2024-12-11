using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Rmn.FinancialDataAnalysis.Repositories.Trackers;
using Rmn.FinancialDataAnalysis.Shared.Tests.DatabaseContext;


namespace Rmn.FinancialDataAnalysis.Shared.Tests.WebHosts;

public class WebHostTest
{
    public IWebHostBuilder WebHostBuilder;

    private readonly MemoryDatabaseTrackerContextTests _trackerContext;
    public TrackerContext TrackerContext => _trackerContext.TrackerContext;

    public WebHostTest()
    {
        _trackerContext = new MemoryDatabaseTrackerContextTests();
    }

    [SetUp]
    public void Setup()
    {
        WebHostBuilder = CreateHostBuilder();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _trackerContext.OneTimeTearDown();
    }

    private IWebHostBuilder CreateHostBuilder()
    {
        return new WebHostBuilder()
            .ConfigureAppConfiguration(x => x.AddJsonFile("appsettings.tests.json", optional: true))
            .ConfigureServices(services =>
            {
                services.AddSingleton(TrackerContext);
            })
            .UseStartup<Startup>();
    }
}
