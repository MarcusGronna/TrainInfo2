using Application.Dtos;
using Domain;

namespace Application.Interfaces;

public interface ITrainRepository
{
    Task<List<Train>> GetTrainsAsync();

    Task<Train> GetTrainByIdAsync(Guid id);
    Task<TrainResponse> CreateTrainAsync(TrainRequest request);
}
