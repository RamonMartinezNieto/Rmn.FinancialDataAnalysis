using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmn.FinancialDataAnalysis.Business.Trackers;

public interface ITrackerRepository
{
    Task<IEnumerable<Tracker>> GetAll();
    Task<Tracker> Get(Guid trackerId);
    Task<Tracker> Create(string name, string description, string expansionTracker);
    Task<bool> Delete(Guid trackerId);
}