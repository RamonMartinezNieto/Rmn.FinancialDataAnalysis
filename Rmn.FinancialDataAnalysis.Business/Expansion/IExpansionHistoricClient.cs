using System.Threading.Tasks;
using Rmn.FinancialDataAnalysis.Business.Expansion;

namespace Rmn.FinancialDataAnalysis.Clients;

public interface IExpansionHistoricClient
{
    Task<ExpansionData> Get(ExpansionRequest request);
}