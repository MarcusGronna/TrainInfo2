using Application.Dtos;
using Application.Interfaces;
using Domain;
using Infrastructure.DatabaseContext;

namespace Infrastructure.Repositories;

public class TrainRepository : ITrainRepository
{
    private TrainContext _db;

    public TrainRepository(TrainContext db)
    {
        _db = db;
    }

    public async Task<Train> GetTrainAsync()
    {
        return new Train { Id = Guid.NewGuid(), Model = "X60", Number = "6066" };
    }

    public async Task<TrainResponse> CreateTrainAsync(TrainRequest request)
    {
        var train = new Train
        {
            Id = Guid.NewGuid(),
            Model = request.Model,
            Number = request.Number
        };

        try
        {
            await _db.AddAsync<Train>(train);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to database: {ex.Message}");
        }

        return new TrainResponse
            (
                Id : train.Id,
                Model : request.Model,
                Number : request.Number
            );
    }
}