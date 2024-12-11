using FluentAssertions;
using Rmn.FinancialDataAnalysis.Business.Expansion;
using Rmn.FinancialDataAnalysis.Business.Expansion.Models;

namespace Rmn.FinancialDataAnalysis.Business.Tests.Expansion;

public class ExpansionRequestTests
{
    [Test]
    public void ExpansionRequestConvertToParams()
    {
        var request = new ExpansionRequest()
        {
            Month = 3,
            Year = 2021,
            Tracker = "TCR"
        };
        
        var result = request.ConvertToParams();

        result.Should().BeEquivalentTo(new Dictionary<string, string>
        {
            { "cod", "TCR" },
            { "anyo", "2021" },
            { "mes", "3" }
        });
    }
}