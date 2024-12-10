using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Rmn.FinancialDataAnalysis.Shared.Tests.DatabaseContext;


namespace Rmn.FinancialDataAnalysis.Shared.Tests.WebHosts;

public class WebHostTest : MemoryDatabaseTrackerContextTests
{
    public IWebHostBuilder WebHostBuilder;

    public WebHostTest()
    {
        base.Setup();
    }

    [SetUp]
    public void Setup()
    {
        WebHostBuilder = CreateHostBuilder();
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
