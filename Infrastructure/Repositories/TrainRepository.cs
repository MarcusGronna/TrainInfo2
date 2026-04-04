using Application.Interfaces;
using Domain;

namespace Infrastructure.Repositories;

public class TrainRepository : ITrainRepository
{
    public async Task<Train> GetTrainAsync()
    {
        return new Train { Id = Guid.NewGuid(), Model = "X60", Number = "6066" };
    }
}