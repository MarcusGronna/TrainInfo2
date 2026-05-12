using Api.Controllers;
using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.Api;

public class ControllerTests
{
    private readonly Mock<ITrainService> _serviceMock;
    private readonly HttpClient client = new HttpClient();
    private readonly TrainsController _controller;

    public ControllerTests()
    {
        var nullLogger = Microsoft.Extensions.Logging.Abstractions.NullLogger<TrainsController>.Instance;
        _serviceMock = new Mock<ITrainService>();
        _controller = new TrainsController(_serviceMock.Object, nullLogger);
    }

    // TODO - Fix this test so it test the right thing
    [Fact]
    public async Task GetTrains_ShouldReturnTrains_WhenTrainsExist()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        List<TrainResponse> expectedTrain = new List<TrainResponse>{
            new TrainResponse
        (
            Id : id,
            Model : "Rc6",
            Number : "6066"
        ) };

        _serviceMock
            .Setup(s => s.GetTrainsAsync())
            .ReturnsAsync(expectedTrain);

        // Act
        var result = await _controller.GetTrains();
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        // Assert
        Assert.Equal(expectedTrain, okResult.Value);
    }

    [Fact]
    public async Task GetTrainById_ShouldReturn404_WhenResourceNotFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        _serviceMock
            .Setup(s => s.GetTrainByIdAsync(id))
            .ReturnsAsync((TrainResponse?)null);

        // Act
        var result = await _controller.GetTrainById(id);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateTrain_ShouldReturn400_WhenIncorrectDataIsReceived()
    {
        // Arrange
        var request = new TrainRequest(string.Empty, string.Empty);
        _serviceMock
            .Setup(s => s.CreateTrainAsync(It.IsAny<TrainRequest>()));

        // Act
        var result = await _controller.CreateTrain(request);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public async Task Update_ShouldReturn400_WhenIncorrectDataIsReceived()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = new TrainUpdateRequest(string.Empty, string.Empty);
        _serviceMock
            .Setup(s => s.UpdateTrainByIdAsync(It.IsAny<TrainUpdateRequest>(), id))
            .ThrowsAsync(new ArgumentException());

        // Act
        var result = await _controller.UpdateTrain(request, id);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }
}
