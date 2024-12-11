using System.Text.Json.Serialization;

namespace Rmn.FinancialDataAnalysis.Business.Expansion.Models;

public class ExpansionData
{
    [JsonPropertyName("valor")]
    public Data Data { get; set; }
}