namespace Rmn.FinancialDataAnalysis.Infrastructure.Trackers;

public class TrackerService : ITrackerService
{
    private readonly ITrackerRepository _repository;

    public TrackerService(ITrackerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Tracker>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Tracker> Get(Guid trackerId)
    {
        return await _repository.Get(trackerId);
    }

    public async Task<Guid> Create(string name, string description, string expansionTracker)
    {
        var tracker = await _repository.Create(name, description, expansionTracker);
        return tracker.Id;
    }

    public async Task<bool> Delete(Guid trackerId)
    {
        return await _repository.Delete(trackerId);
    }
}