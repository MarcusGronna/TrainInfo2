using Application.Dtos;
using Domain;

namespace Application.Interfaces;

public interface ITrainRepository
{
    Task<List<Train>> GetTrainsAsync();
    Task<TrainResponse> CreateTrainAsync(TrainRequest request);
}
