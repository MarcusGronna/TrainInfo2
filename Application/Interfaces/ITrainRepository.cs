using Application.Dtos;
using Domain;

namespace Application.Interfaces;

public interface ITrainRepository
{
    Task<List<Train>> GetTrainsAsync();

    Task<Train> GetTrainByIdAsync(Guid id);
    Task<bool> CreateTrainAsync(Train train);
    Task<Train> UpdateTrainByIdAsync(Train train, Guid id);
}
