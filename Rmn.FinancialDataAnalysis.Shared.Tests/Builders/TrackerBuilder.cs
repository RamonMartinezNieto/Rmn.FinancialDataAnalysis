using Rmn.FinancialDataAnalysis.Dtos;
using System;
using Rmn.FinancialDataAnalysis.Business.Trackers.Models;

namespace Rmn.FinancialDataAnalysis.Shared.Tests.Builders;

public class TrackerBuilder
{
    private readonly Tracker _tracker;

    public TrackerBuilder()
    {
        _tracker = new Tracker();
        _tracker.Id = Guid.NewGuid();
    }

    public TrackerBuilder WithName(string name)
    {
        _tracker.Name = name;
        return this;
    }

    public TrackerBuilder WithDescription(string description)
    {
        _tracker.Description = description;
        return this;
    }

    public TrackerBuilder WithExpansionTracker(string expansionTracker)
    {
        _tracker.ExpansionTracker = expansionTracker;
        return this;
    }

    public Tracker BuildTrackerEntity()
    {
        return _tracker;
    }

    public TrackerDto BuildTrackerDto()
    {
        return new TrackerDto(_tracker.Id, _tracker.Name, _tracker.Description, _tracker.ExpansionTracker);
    }
}