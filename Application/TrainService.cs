using Application.Dtos;
using Application.Interfaces;
using Domain;

namespace Application;

public class TrainService : ITrainService
{
    private readonly ITrainRepository _trainRepo;

    public TrainService(ITrainRepository trainRepo)
    {
        _trainRepo = trainRepo;
    }

    public async Task<List<TrainResponse>> GetTrainsResponseAsync()
    {
        List<Train> trains = await _trainRepo.GetTrainsAsync();
        List<TrainResponse> response = new List<TrainResponse>();

        foreach (Train t in trains)
        {
            response.Add(
            new TrainResponse(
            Id: t.Id,
            Model: t.Model,
            Number: t.Number));
        }

        return response;
    }

    public async Task<TrainResponse> GetTrainResponseByIdAsync(Guid id)
    {
        var train = await _trainRepo.GetTrainByIdAsync(id);
        var response = new TrainResponse(
            Id : train.Id, 
            Model : train.Model, 
            Number : train.Number
        );

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

        bool isCreated = await _trainRepo.CreateTrainAsync(train);

        if (isCreated)
        {
            return new TrainResponse(
                Id : train.Id,
                Model : train.Model,
                Number : train.Number
            );
        }

        return null!;
    }

    public async Task<TrainResponse> UpdateTrainResponseByIdAsync(TrainRequest request, Guid id)
    {
        try
        {
            var train = new Train
            {
                Id = id,
                Model = request.Model,
                Number = request.Number
            };

            var updatedTrain = await _trainRepo.UpdateTrainByIdAsync(train, id);

            var response = new TrainResponse(
                Id: updatedTrain.Id,
                Model: updatedTrain.Model,
                Number: updatedTrain.Number
            );

            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not update train: {id}. Error: {ex.Message}");
            
            return null!;
        }
    }
}
