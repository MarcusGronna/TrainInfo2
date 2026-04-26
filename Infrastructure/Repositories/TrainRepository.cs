using Application.Interfaces;
using Domain;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Repositories;

public class TrainRepository : ITrainRepository
{
    private TrainDbContext _db;

    public TrainRepository(TrainDbContext db)
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

    public async Task<bool> UpdateTrainByIdAsync(Train train, Guid id)
    {
        try
        {
            var currentTrain = await _db.Trains.FindAsync(id);

            if (currentTrain is null)
            {
                throw new RowNotInTableException();
            }

            _db.Entry(currentTrain).CurrentValues.SetValues(train);

            await _db.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to database: {ex.Message}");

            return false;
        }
    }
}