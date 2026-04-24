using Api.Controllers;
using Application.Interfaces;
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
    public async Task ShouldReturn404_WhenResourceNotFound()
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
}
