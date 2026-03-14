using Domain;

namespace Application;

public interface ITrainRepository
{
    Task<Train> GetTrainAsync();
}
