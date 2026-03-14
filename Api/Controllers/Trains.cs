using Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/trains")]
[ApiController]
public class TrainsController : ControllerBase
{
    private readonly ITrainRepository _trainRepo;

    public TrainsController(ITrainRepository trainRepo)
    {
        _trainRepo = trainRepo;
    }

    [HttpGet]
    public async Task<ActionResult<TrainResponse>> GetTrains()
    {
        TrainResponse response = await _trainRepo.GetTrainAsync();
        
        return Ok(response);
    }
}
