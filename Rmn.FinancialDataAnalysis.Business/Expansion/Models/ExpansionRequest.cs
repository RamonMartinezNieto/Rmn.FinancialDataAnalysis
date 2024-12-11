using System.Collections.Generic;

namespace Rmn.FinancialDataAnalysis.Business.Expansion.Models;

public class ExpansionRequest
{
    public string Tracker { get; init; }
    public int Year { get; init; }
    public int Month { get; init; }
    
    public Dictionary<string, string> ConvertToParams()
    {
        return new Dictionary<string, string>
        {
            { "cod", Tracker },
            { "anyo", Year.ToString() },
            { "mes", Month.ToString() }
        };
    }
}