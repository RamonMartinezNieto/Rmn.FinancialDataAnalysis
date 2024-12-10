﻿using System;
using Microsoft.EntityFrameworkCore;
using Rmn.FinancialDataAnalysis.Business.Trackers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Org.BouncyCastle.Tls.Crypto.Impl.BC;

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

    public async Task<Tracker> GetTrackerById(Guid trackerId)
    {
        return await _context.Trackers.FindAsync(trackerId);
    }

    public async Task<Tracker> Create(string name, string description, string expansionTracker)
    {
        var tracker = new Tracker()
        {
            Name = name,
            Description = description,
            ExpansionTracker = expansionTracker
        };
        await _context.Trackers.AddAsync(tracker);
        await _context.SaveChangesAsync();
        return tracker;
    }

    public async Task<bool> DeleteTracker(Guid trackerId)
    {
        var tracker = await _context.Trackers.FindAsync(trackerId);
        if (tracker == null) return false;

        _context.Trackers.Remove(tracker);
        var rowsDeleted = await _context.SaveChangesAsync();
        return rowsDeleted > 0;
    }
}