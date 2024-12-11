using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Rmn.FinancialDataAnalysis.Services.Trackers;
using System.Text;
using Microsoft.Net.Http.Headers;
using Rmn.FinancialDataAnalysis.Business.Expansion;
using Rmn.FinancialDataAnalysis.Clients;
using Rmn.FinancialDataAnalysis.Services.Expansion.Clients;
using Rmn.FinancialDataAnalysis.Services.Expansion.Providers;

namespace Rmn.FinancialDataAnalysis;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        services.AddControllers();

        services.AddDbContext<TrackerContext>(options =>
        {
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("Rmn.FinancialDataAnalysis.Migrations"));
        });

        services.AddTransient<ITrackerRepository, TrackerRepository>();
        services.AddTransient<ITrackerService, TrackerService>();
        
        services.AddHttpClient<IExpansionHistoricClient, ExpansionHistoricClient>()
            .ConfigureHttpClient((sp, client) =>
            {
                client.BaseAddress = new Uri(Configuration.GetValue<string>("Clients:Expansion:BaseUrl"));
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, Configuration.GetValue<string>("Clients:Expansion:AcceptedType"));
            });
        
        services.AddScoped<IExpansionHistoricProvider, ExpansionHistoricProvider>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rmn.FinancialDataAnalysis", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rmn.FinancialDataAnalysis v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}