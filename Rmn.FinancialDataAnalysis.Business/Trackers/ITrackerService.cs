using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rmn.FinancialDataAnalysis.Business.Trackers.Models;

namespace Rmn.FinancialDataAnalysis.Business.Trackers;

public interface ITrackerService
{
    Task<IEnumerable<Tracker>> GetAll();
    Task<Tracker> Get(Guid trackerId);
    Task<Guid> Create(string name, string description, string expansionTracker);
    Task<bool> Delete(Guid trackerId);
}