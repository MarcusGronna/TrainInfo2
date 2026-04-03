using Domain;

namespace Application.Interfaces;

public interface ITrainRepository
{
    Task<Train> GetTrainAsync();
}
