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

    public async Task<bool> CreateTrainAsync(Train train)
    {
        try
        {
            await _db.AddAsync<Train>(train);
            await _db.SaveChangesAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to database: {ex.Message}");
            
            return false;
        }
    }

    public async Task<Train> UpdateTrainByIdAsync(Train train, Guid id)
    {
        var trainToUpdate = await _db.Trains
            .FirstOrDefaultAsync(t => t.Id == id);

        if (trainToUpdate is null)
        {
            return null;
        }

        trainToUpdate.Model = trainToUpdate.Model == train.Model ? trainToUpdate.Model : train.Model;
        trainToUpdate.Number = trainToUpdate.Number == train.Number ? trainToUpdate.Number : train.Model;

        await _db.Trains.AddAsync(trainToUpdate);
        await _db.SaveChangesAsync();

        return trainToUpdate;
    }
}