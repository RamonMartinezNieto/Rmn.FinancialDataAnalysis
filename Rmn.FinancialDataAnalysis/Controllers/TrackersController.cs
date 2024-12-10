using Rmn.FinancialDataAnalysis.Business.Trackers;

namespace Rmn.FinancialDataAnalysis.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TrackersController : ControllerBase
{
    private readonly ITrackerService _service;
    private readonly TrackerMapper _mapper;

    public TrackersController(ITrackerService service, TrackerMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("GetTrackers")]
    public async Task<IEnumerable<TrackerDto>> GetTrackers()
    {
        var result = await _service.GetTrackers();
        return _mapper.ToDto(result);
    }
}
