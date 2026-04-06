using Application.Dtos;

namespace Application.Interfaces
{
    public interface ITrainService
    {
        Task<List<TrainResponse>> GetTrainsResponseAsync();
        Task<TrainResponse> CreateTrainAsync(TrainRequest request);
    }
}