﻿using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Rmn.FinancialDataAnalysis.Repositories.Trackers;

namespace Rmn.FinancialDataAnalysis.Shared.Tests.DatabaseContext;

public class MemoryDatabaseTrackerContextTests
{
    public DbContextOptions<TrackerContext> OptionsContext;
    public TrackerContext TrackerContext;

    public MemoryDatabaseTrackerContextTests()
    {
        Setup();
    }

    [OneTimeSetUp]
    public void Setup()
    {
        OptionsContext = new DbContextOptionsBuilder<TrackerContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        TrackerContext = new TrackerContext(OptionsContext);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        DisposeTrackerContext();
    }

    private void DisposeTrackerContext()
    {
        if (TrackerContext is not null)
        {
            TrackerContext.Database.EnsureDeleted();
            TrackerContext.Dispose();
        }
    }
}