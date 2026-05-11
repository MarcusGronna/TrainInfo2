using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/trains")]
[ApiController]
public class TrainsController : ControllerBase
{
    private readonly ILogger<TrainsController>? _logger;
    private readonly ITrainService _trainService;

    public TrainsController(ITrainService trainService, ILogger<TrainsController> logger)
    {
        _trainService = trainService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<TrainResponse>>> GetTrains()
    {
        List<TrainResponse> response = await _trainService.GetTrainsAsync();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrainResponse>> GetTrainById(Guid id)
    {
        var response = await _trainService.GetTrainByIdAsync(id);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<TrainResponse>> CreateTrain(TrainRequest request)
    {
        try
        {
            TrainResponse response = await _trainService.CreateTrainAsync(request);

            return CreatedAtAction(nameof(GetTrainById), new { id = response.Id }, response);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateTrain(TrainUpdateRequest request, Guid id)
    {
        try
        {
            TrainResponse response = await _trainService.UpdateTrainByIdAsync(request, id);

            return Ok();
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
    }
}
