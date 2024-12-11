using Riok.Mapperly.Abstractions;
using Rmn.FinancialDataAnalysis.Business.Expansion;
using Rmn.FinancialDataAnalysis.Controllers;

namespace Rmn.FinancialDataAnalysis.Mappers;

[Mapper]
public partial class ExpansionMapper
{
    public partial ExpansionRequest ToEntity(ExpansionRequestDto expansionRequestDto);
}