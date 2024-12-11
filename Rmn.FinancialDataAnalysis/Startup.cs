using Rmn.FinancialDataAnalysis.Infrastructure.Expansion;
using Rmn.FinancialDataAnalysis.Repositories.Trackers;
using Rmn.FinancialDataAnalysis.Infrastructure.Trackers;

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
        
        services.AddHttpClient<IExpansionHistoricService, ExpansionHistoricService>()
            .ConfigureHttpClient((sp, client) =>
            {
                client.BaseAddress = new Uri(Configuration.GetValue<string>("Clients:Expansion:BaseUrl"));
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, Configuration.GetValue<string>("Clients:Expansion:AcceptedType"));
            });
        
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