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
}