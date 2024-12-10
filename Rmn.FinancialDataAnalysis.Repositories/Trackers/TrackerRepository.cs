using Microsoft.EntityFrameworkCore;
using Rmn.FinancialDataAnalysis.Business.Trackers;
using Rmn.FinancialDataAnalysis.Migrations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmn.FinancialDataAnalysis.Repositories.Trackers;

public class TrackerRepository : ITrackerRepository
{
    private readonly TrackerContext _context;

    public TrackerRepository(TrackerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tracker>> GetTrackers()
    {
        return await _context.Trackers.ToListAsync();
    }
}