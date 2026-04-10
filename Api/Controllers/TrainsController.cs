using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/trains")]
[ApiController]
public class TrainsController : ControllerBase
{
    private readonly ITrainService _trainService;

    public TrainsController(ITrainService trainService)
    {
        _trainService = trainService;
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

    [HttpPatch("{id}")]
    public async Task<ActionResult<TrainResponse>> UpdateTrainById(TrainRequest request, Guid id)
    {
        TrainResponse response = await _trainService.UpdateTrainResponseByIdAsync(request, id);

        return CreatedAtAction(nameof(GetTrainById), response);
    }
}
