using System.Threading.Tasks;
using Rmn.FinancialDataAnalysis.Business.Expansion.Models;

namespace Rmn.FinancialDataAnalysis.Business.Expansion;

public interface IExpansionHistoricService
{
    Task<ExpansionData> Get(ExpansionRequest request);
}