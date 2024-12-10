using Microsoft.EntityFrameworkCore;
using Rmn.FinancialDataAnalysis.Business.Trackers;

namespace Rmn.FinancialDataAnalysis.Migrations;

public class TrackerContext : DbContext
{
    public virtual DbSet<Tracker> Trackers { get; set; }

    public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
    {
    }
}
