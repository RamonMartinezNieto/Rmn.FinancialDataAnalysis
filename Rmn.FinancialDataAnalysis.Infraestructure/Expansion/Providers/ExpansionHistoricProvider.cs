using System.Threading.Tasks;
using Rmn.FinancialDataAnalysis.Business.Expansion;
using Rmn.FinancialDataAnalysis.Clients;

namespace Rmn.FinancialDataAnalysis.Services.Expansion.Providers;

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