using Application.Dtos;

namespace Application.Interfaces
{
    public interface ITrainService
    {
        Task<TrainResponse> GetTrainResponseAsync();
        Task<TrainResponse> CreateTrainAsync(TrainRequest request);
    }
}