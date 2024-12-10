﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmn.FinancialDataAnalysis.Business.Trackers;

public interface ITrackerRepository
{
    Task<IEnumerable<Tracker>> GetTrackers();
    Task<Tracker> GetTrackerById(Guid trackerId);
    Task<Tracker> Create(string name, string description, string expansionTracker);
    Task<bool> DeleteTracker(Guid trackerId);
}