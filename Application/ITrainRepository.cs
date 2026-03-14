using Domain;

namespace Application;

public interface ITrainRepository
{
    Task<TrainResponse> GetTrainAsync();
}
