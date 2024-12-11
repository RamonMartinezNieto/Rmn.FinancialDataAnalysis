using System.Threading.Tasks;

namespace Rmn.FinancialDataAnalysis.Business.Expansion;

public interface IExpansionHistoricProvider
{
    Task<ExpansionData> Get(ExpansionRequest request);
}