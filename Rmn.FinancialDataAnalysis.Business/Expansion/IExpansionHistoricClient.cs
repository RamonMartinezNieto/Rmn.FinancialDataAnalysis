using System.Threading.Tasks;
using Rmn.FinancialDataAnalysis.Business.Expansion.Models;

namespace Rmn.FinancialDataAnalysis.Business.Expansion;

public interface IExpansionHistoricClient
{
    Task<ExpansionData> Get(ExpansionRequest request);
}