using FluentAssertions;
using NSubstitute;
using Rmn.FinancialDataAnalysis.Business.Expansion;
using Rmn.FinancialDataAnalysis.Clients;
using Rmn.FinancialDataAnalysis.Services.Expansion.Providers;

namespace Rmn.FinancialDataAnalysis.Tests.Providers;

public class HistoricDataProviderTests
{
    [Test]
    public async Task GetPageFromClient()
    {
        var exampleJson = @"
        {
            ""valor"": {
                ""cotizaciones"": [ {}, {}, {} ],
                ""nombre"": ""IBEX 35""
            }
        }";
        
        var client = Substitute.For<IExpansionHistoricClient>();
        client.Get(Arg.Any<ExpansionRequest>()).Returns(new ExpansionData()
        {
            Data = new Data()
                {
                    Name = "IBEX 35",
                    Quotes = new ExpansionQuotes[]
                    {
                        new ExpansionQuotes(),
                        new ExpansionQuotes(),
                        new ExpansionQuotes()
                    }
                }
        });
        
        var provier  = new ExpansionHistoricProvider(client);

        var request = new ExpansionRequest()
        {
            Tracker = "I.IB",
            Year = 2024,
            Month = 11,
        };

        var result = await provier.Get(request);

        result.Data.Quotes.Should().HaveCount(3);
        result.Data.Name.Should().Be("IBEX 35");
    }
}

