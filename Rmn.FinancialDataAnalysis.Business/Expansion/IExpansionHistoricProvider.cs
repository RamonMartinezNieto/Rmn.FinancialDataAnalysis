using System.Threading.Tasks;
using Rmn.FinancialDataAnalysis.Business.Expansion.Models;

namespace Rmn.FinancialDataAnalysis.Business.Expansion;

public interface IExpansionHistoricProvider
{
    Task<ExpansionData> Get(ExpansionRequest request);
}