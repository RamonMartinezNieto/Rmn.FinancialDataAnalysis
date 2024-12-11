namespace Rmn.FinancialDataAnalysis.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ExpansionController : ControllerBase
{
    private readonly IExpansionHistoricProvider _provider;
    private readonly ExpansionMapper _mapper;

    public ExpansionController(IExpansionHistoricProvider provider)
    {
       _provider = provider;
       _mapper = new ExpansionMapper();
    }

    [HttpPost("GetMonth")]
    public async Task<ExpansionData> Get([FromBody] ExpansionRequestDto request)
    {
        return await _provider.Get(_mapper.ToEntity(request));
    }
}