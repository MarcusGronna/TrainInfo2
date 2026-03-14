using Application;
using Domain;

namespace Infrastructure;

public class TrainRepository : ITrainRepository
{
    public async Task<TrainResponse> GetTrainAsync()
    {
        Train t = new Train { Id = Guid.NewGuid(), Model = "X60", Number = "6066" };

        return new TrainResponse(Id: t.Id, Model: t.Model, Number: t.Number);
    }
}