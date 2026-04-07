using Application.Dtos;
using Application.Interfaces;
using Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/trains")]
[ApiController]
public class TrainsController : ControllerBase
{
    private readonly ITrainService _trainService;
    private readonly TrainContext _db;

    public TrainsController(ITrainService trainService, TrainContext context)
    {
        _trainService = trainService;
        _db = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<TrainResponse>>> GetTrains()
    {
        List<TrainResponse> response = await _trainService.GetTrainsResponseAsync();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrainResponse>> GetTrainById(Guid id)
    {
        var response = await _trainService.GetTrainResponseByIdAsync(id);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<TrainResponse>> CreateTrain(TrainRequest request)
    {
        TrainResponse response = await _trainService.CreateTrainAsync(request); 

        return CreatedAtAction(nameof(GetTrains), response);
    }
}
