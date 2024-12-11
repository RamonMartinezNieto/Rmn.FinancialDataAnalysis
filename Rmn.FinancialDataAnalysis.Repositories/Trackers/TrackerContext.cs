using Microsoft.EntityFrameworkCore;
using Rmn.FinancialDataAnalysis.Business.Trackers.Models;

namespace Rmn.FinancialDataAnalysis.Repositories.Trackers;

public class TrackerContext : DbContext
{
    public virtual DbSet<Tracker> Trackers { get; set; }

    public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
    {
    }
}
