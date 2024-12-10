using Riok.Mapperly.Abstractions;
using Rmn.FinancialDataAnalysis.Business.Trackers;

namespace Rmn.FinancialDataAnalysis.Mappers;

[Mapper]
public partial class TrackerMapper
{
    public partial TrackerDto ToDto(Tracker tracker);
    public partial IEnumerable<TrackerDto> ToDto(IEnumerable<Tracker> tracker);
    public partial Tracker ToEntity(TrackerDto dto);
}
