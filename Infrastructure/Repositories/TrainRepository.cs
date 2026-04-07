using Application.Dtos;
using Application.Interfaces;
using Domain;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Repositories;

public class TrainRepository : ITrainRepository
{
    private TrainContext _db;

    public TrainRepository(TrainContext db)
    {
        _db = db;
    }

    public async Task<List<Train>> GetTrainsAsync()
    {
        return await _db.Trains.ToListAsync();
    }

    public async Task<Train> GetTrainByIdAsync(Guid id)
    {
        var response = await _db.Trains
            .FirstOrDefaultAsync(t => t.Id == id);

        if (response is null) throw new RowNotInTableException();

        return response;
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