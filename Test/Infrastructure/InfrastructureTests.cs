using Application.Interfaces;
using Domain;
using Moq;

namespace Tests.Infrastructure
{
    public class InfrastructureTests
    {
        [Fact]
        public async Task GetTrainByIdAsync_IsCalled_ShouldReturnTrainNumber6066()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var t = new Train
            {
                Id = id,
                Model = "Rc6",
                Number = "6066"
            };

            var mock = new Mock<ITrainRepository>();
            mock.Setup(repo => repo.GetTrainByIdAsync(id)).ReturnsAsync(t);
            var repo = mock.Object;

            // Act
            var train = await repo.GetTrainByIdAsync(id);


            // Assert
            Assert.Equal("6066", train.Number);
        }
    }
}
