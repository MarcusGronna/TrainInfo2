using Api.Controllers;
using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Data;

namespace Tests.Api;

public class ControllerTests
{
    private readonly Mock<ITrainService> _serviceMock;
    private readonly TrainsController _controller;

    public ControllerTests()
    {
        _serviceMock = new Mock<ITrainService>();
        _controller = new TrainsController(_serviceMock.Object);
    }

    [Fact]
    public async Task GetTrainById_ShouldReturn404_WhenResourceNotFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        _serviceMock
            .Setup(s => s.GetTrainResponseByIdAsync(id))
            .ThrowsAsync(new RowNotInTableException());

        // Act
        var result = await _controller.GetTrainById(id);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateTrain_ShouldReturn400_WhenIncorrectDataIsRecieved()
    {
        // Arrange
        var request = new TrainRequest(string.Empty, string.Empty);
        _serviceMock
            .Setup(s => s.CreateTrainAsync(It.IsAny<TrainRequest>()))
            .ThrowsAsync(new ArgumentException());

        // Act
        var result = await _controller.CreateTrain(request);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public async Task Update_ShouldReturn400_WhenIncorrectDataIsRecieved()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = new TrainUpdateRequest(string.Empty, string.Empty);
        _serviceMock
            .Setup(s => s.UpdateTrainResponseByIdAsync(It.IsAny<TrainUpdateRequest>(), id))
            .ThrowsAsync(new ArgumentException());

        // Act
        var result = await _controller.Update(request, id);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }
}
