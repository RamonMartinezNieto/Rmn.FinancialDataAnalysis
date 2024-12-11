using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rmn.FinancialDataAnalysis.Business.Expansion;
using Rmn.FinancialDataAnalysis.Clients;

namespace Rmn.FinancialDataAnalysis.Services.Expansion.Clients;

public class ExpansionHistoricClient : IExpansionHistoricClient
{
    private readonly HttpClient _httpClient;

    public ExpansionHistoricClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ExpansionData> Get(ExpansionRequest request)
    {
        //FOR TEST IBEX 35 ?cod=I.IB&llave=&anyo=2024&mes=11
        var queryParams = request.ConvertToParams();
        var uriBuilder = CreateUriBuilder(queryParams);
        return await _httpClient.GetFromJsonAsync<ExpansionData>(uriBuilder.Uri);
    }
    
    public UriBuilder CreateUriBuilder(Dictionary<string, string> queryParams)
    {
        var uriBuilder = new UriBuilder(_httpClient.BaseAddress!);
        var query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString((string)kvp.Value)}"));
        uriBuilder.Query = query;
        return uriBuilder;
    }
}