using System.Text.Json.Serialization;

namespace Rmn.FinancialDataAnalysis.Business.Expansion.Models;

public class ExpansionQuotes
{
    [JsonPropertyName("precio")]
    public string Price { get; set; }
    [JsonPropertyName("precio_anterior")]
    public string LastPrice { get; set; }
    [JsonPropertyName("diferencia")]
    public string Difference { get; set; }
    [JsonPropertyName("rentabilidad")]
    public string Revenue { get; set; }
    [JsonPropertyName("fecha")]
    public string Date { get; set; }
}