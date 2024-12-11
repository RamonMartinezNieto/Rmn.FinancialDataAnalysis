namespace Rmn.FinancialDataAnalysis.Infrastructure.Expansion.Providers;

public class ExpansionHistoricProvider : IExpansionHistoricProvider
{
    private readonly IExpansionHistoricClient _client;
    
    public ExpansionHistoricProvider(IExpansionHistoricClient client)
    {
        _client = client;
    }

    public async Task<ExpansionData> Get(ExpansionRequest request)
    {
        return await _client.Get(request);
    }
}