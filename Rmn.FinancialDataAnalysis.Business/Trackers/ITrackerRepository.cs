using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmn.FinancialDataAnalysis.Business.Trackers;

public interface ITrackerRepository
{
    Task<IEnumerable<Tracker>> GetTrackers();
}