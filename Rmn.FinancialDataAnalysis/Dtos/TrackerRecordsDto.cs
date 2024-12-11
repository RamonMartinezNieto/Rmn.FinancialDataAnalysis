namespace Rmn.FinancialDataAnalysis.Dtos;

public record TrackerDto(
    Guid Id,
    string Name,
    string Description,
    string ExpansionTracker);
    
public record CreateTrackerDto(
    string Name,
    string Description,
    string ExpansionTracker);