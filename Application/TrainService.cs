using Application.Dtos;
using Application.Interfaces;
using Domain;

namespace Application;

public class TrainService : ITrainService
{
    private readonly ITrainRepository _trainRepo;

    public TrainService(ITrainRepository trainRepo)
    {
        _trainRepo = trainRepo;
    }

    public async Task<List<TrainResponse>> GetTrainsResponseAsync()
    {
        List<Train> trains = await _trainRepo.GetTrainsAsync();
        List<TrainResponse> response = new List<TrainResponse>();

        foreach (Train t in trains)
        {
            response.Add(
            new TrainResponse(
            Id: t.Id,
            Model: t.Model,
            Number: t.Number));
        }

        return response;
    }

    public async Task<TrainResponse> CreateTrainAsync(TrainRequest request)
    {
        return await _trainRepo.CreateTrainAsync(request);
    }
}
