﻿namespace Rmn.FinancialDataAnalysis.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TrackersController : ControllerBase
{
    private readonly ITrackerService _service;
    private readonly TrackerMapper _mapper;

    public TrackersController(ITrackerService service)
    {
        _service = service;
        _mapper = new TrackerMapper();
    }

    [HttpGet("GetAll")]
    public async Task<IEnumerable<TrackerDto>> GetAll()
    {
        var result = await _service.GetAll();
        return _mapper.ToDto(result);
    }
    
    [HttpGet("Get")]
    public async Task<TrackerDto> Get([FromQuery] Guid trackerId)
    {
        var result = await _service.Get(trackerId);
        return _mapper.ToDto(result);
    }

    [HttpPost("Create")]
    public async Task<Guid> Create([FromBody] CreateTrackerDto createTrackerDto)
    {
        return await _service.Create(createTrackerDto.Name, createTrackerDto.Description, createTrackerDto.ExpansionTracker);
    }
    
    [HttpDelete("Delete")]
    public async Task<bool> Delete([FromQuery] Guid trackerId)
    {
        return await _service.Delete(trackerId);
    }
}
