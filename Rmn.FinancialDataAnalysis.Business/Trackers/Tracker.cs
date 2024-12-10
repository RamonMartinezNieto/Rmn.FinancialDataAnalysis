using System;

namespace Rmn.FinancialDataAnalysis.Business.Trackers;

public class Tracker
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ExpansionTracker { get; set; }

}
