namespace Rmn.FinancialDataAnalysis.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ExpansionController : ControllerBase
{
    private readonly IExpansionHistoricService _service;
    private readonly ExpansionMapper _mapper;

    public ExpansionController(IExpansionHistoricService service)
    {
       _service = service;
       _mapper = new ExpansionMapper();
    }

    [HttpPost("GetMonth")]
    public async Task<ExpansionData> Get([FromBody] ExpansionRequestDto request)
    {
        return await _service.Get(_mapper.ToEntity(request));
    }
}