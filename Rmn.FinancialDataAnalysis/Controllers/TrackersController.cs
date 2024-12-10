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
    
    [HttpGet("Get")]
    public async Task<TrackerDto> Get(Guid trackerId)
    {
        var result = await _service.GetTrackersById(trackerId);
        return _mapper.ToDto(result);
    }

    [HttpPost("Create")]
    public async Task<Guid> Create([FromBody] CreateTrackerDto createTrackerDto)
    {
        return await _service.Create(createTrackerDto.Name, createTrackerDto.Description, createTrackerDto.ExpansionTracker);
    }
}
