namespace Application
{
    public interface ITrainService
    {
        Task<TrainResponse> GetTrainResponseAsync();
    }
}