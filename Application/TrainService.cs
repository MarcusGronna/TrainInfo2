using Domain;

namespace Application;

public class TrainService : ITrainService
{
    private readonly ITrainRepository _trainRepo;

    public TrainService(ITrainRepository trainRepo)
    {
        _trainRepo = trainRepo;
    }

    public async Task<TrainResponse> GetTrainResponseAsync()
    {
        Train t = await _trainRepo.GetTrainAsync();

        return new TrainResponse(
            Id: t.Id,
            Model: t.Model,
            Number: t.Number);
    }
}
