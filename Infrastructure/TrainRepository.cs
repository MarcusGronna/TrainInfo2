using Application;
using Domain;

namespace Infrastructure;

public class TrainRepository : ITrainRepository
{
    public async Task<Train> GetTrainAsync()
    {
        return new Train { Id = Guid.NewGuid(), Model = "X60", Number = "6066" };
    }
}