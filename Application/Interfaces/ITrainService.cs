using Application.Dtos;

namespace Application.Interfaces;

public interface ITrainService
{
    Task<List<TrainResponse>> GetTrainsResponseAsync();
    Task<TrainResponse> GetTrainResponseByIdAsync(Guid id);
    Task<TrainResponse> CreateTrainAsync(TrainRequest request);
    Task<TrainResponse> UpdateTrainByIdAsync(TrainUpdateRequest request, Guid id);
}