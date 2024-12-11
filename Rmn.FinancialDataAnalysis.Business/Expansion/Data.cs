namespace Rmn.FinancialDataAnalysis.Business.Expansion;

public class Data
{
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string CodTracker { get; set; }
    public string YearRevenue { get; set; }
    public ExpansionQuotes[] Quotes { get; set; }
}