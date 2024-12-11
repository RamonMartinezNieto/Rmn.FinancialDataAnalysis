using Riok.Mapperly.Abstractions;

namespace Rmn.FinancialDataAnalysis.Mappers;

[Mapper]
public partial class ExpansionMapper
{
    public partial ExpansionRequest ToEntity(ExpansionRequestDto expansionRequestDto);
}