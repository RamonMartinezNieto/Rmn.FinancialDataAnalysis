using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmn.FinancialDataAnalysis.Business.Trackers;

public interface ITrackerService
{
    Task<IEnumerable<Tracker>> GetTrackers();
}