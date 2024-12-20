﻿namespace Rmn.FinancialDataAnalysis.Infrastructure.Expansion;

public class ExpansionHistoricService : IExpansionHistoricService
{
    private readonly HttpClient _httpClient;

    public ExpansionHistoricService(HttpClient httpClient)
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