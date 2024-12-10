using System;
using Rmn.FinancialDataAnalysis.Business.Trackers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmn.FinancialDataAnalysis.Services.Trackers;

public class TrackerService : ITrackerService
{
    private readonly ITrackerRepository _repository;

    public TrackerService(ITrackerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Tracker>> GetTrackers()
    {
        return await _repository.GetTrackers();
    }

    public async Task<Tracker> GetTrackersById(Guid trackerId)
    {
        return await _repository.GetTrackerById(trackerId);
    }

    public async Task<Guid> Create(string name, string description, string expansionTracker)
    {
        var tracker = await _repository.Create(name, description, expansionTracker);
        return tracker.Id;
    }

    public async Task<bool> Delete(Guid trackerId)
    {
        return await _repository.DeleteTracker(trackerId);
    }
}