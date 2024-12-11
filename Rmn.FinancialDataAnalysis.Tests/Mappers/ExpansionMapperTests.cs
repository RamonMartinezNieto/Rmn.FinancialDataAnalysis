using FluentAssertions;
using Rmn.FinancialDataAnalysis.Dtos;
using Rmn.FinancialDataAnalysis.Mappers;

namespace Rmn.FinancialDataAnalysis.Tests.Mappers;

public class ExpansionMapperTests
{
    private ExpansionMapper _mapper;
    
    [SetUp]
    public void Setup()
    {
        _mapper = new ExpansionMapper();
    }
    
    [Test]
    public void MapDtoToEntity()
    {
        var expansionRequestDto = new ExpansionRequestDto("tracker", 1111, 1);
        
        var result = _mapper.ToEntity(expansionRequestDto);

        result.Should().BeEquivalentTo(expansionRequestDto);
    }
}