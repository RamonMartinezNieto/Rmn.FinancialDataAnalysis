using System.Text.Json.Serialization;

namespace Rmn.FinancialDataAnalysis.Business.Expansion.Models;

public class Data
{
    [JsonPropertyName("nombre")]
    public string Name { get; set; }
    [JsonPropertyName("nombre_corto")]
    public string ShortName { get; set; }
    [JsonPropertyName("cod_instrumento")]
    public string CodTracker { get; set; }
    [JsonPropertyName("rentabilidad_anual")]
    public string YearRevenue { get; set; }
    [JsonPropertyName("cotizaciones")]
    public ExpansionQuotes[] Quotes { get; set; }
}