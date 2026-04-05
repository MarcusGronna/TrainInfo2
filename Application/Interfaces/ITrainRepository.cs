using Application.Dtos;
using Domain;

namespace Application.Interfaces;

public interface ITrainRepository
{
    Task<Train> GetTrainAsync();
    Task<TrainResponse> CreateTrainAsync(TrainRequest request);
}
