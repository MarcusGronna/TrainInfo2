using Application.Interfaces;
using Domain;
using Infrastructure;

namespace Tests.Infrastructure
{
    public class InfrastructureTests
    {
        [Fact]
        public async Task GetTrainAsync_IsCalled_ShouldReturnTrainNumber6066()
        {
            // Arrange
            ITrainRepository repo = new TrainRepository();

            // Act
            Train train = await repo.GetTrainAsync();
            string number = train.Number;

            // Assert
            Assert.Equal("6066", number);
        }
    }
}
