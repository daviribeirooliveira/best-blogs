using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Controllers;
using Api.Tests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Entities;
using Model.ViewModels;
using Moq;
using Service.Interfaces;
using Xunit;

namespace Api.Tests
{
    public class CommentControllerTests
    {
        [Fact]
        public async Task GetAll_Returns_Existing_Comments()
        {
            // Arrange
            var commentServiceMock = new Mock<ICommentService>();

            var viewModels = CommentViewModelFixture.Generate();

            commentServiceMock.Setup(service => service.GetAll()).ReturnsAsync(viewModels);

            // Act
            var response = await new CommentController(commentServiceMock.Object).GetAll();

            // Assert
            commentServiceMock.Verify(service => service.GetAll(), Times.Once);

            var okObjectResult = Assert.IsType<OkObjectResult>(response.Result);

            Assert.Equal(viewModels, okObjectResult.Value);
        }

        [Fact]
        public async Task Get_Returns_Existing_Comment()
        {
            // Arrange
            var commentServiceMock = new Mock<ICommentService>();

            var commentId = Guid.NewGuid();

            var viewModel = CommentViewModelFixture.Generate(1).First();

            commentServiceMock.Setup(service => service.Get(commentId)).ReturnsAsync(viewModel);

            // Act
            var response = await new CommentController(commentServiceMock.Object).Get(commentId);

            // Assert
            commentServiceMock.Verify(service => service.Get(commentId), Times.Once);

            var okObjectResult = Assert.IsType<OkObjectResult>(response.Result);

            Assert.Equal(viewModel, okObjectResult.Value);
        }

        [Fact]
        public async Task Post_Creates_And_Returns_Created_Comment()
        {
            // Arrange
            var mapper = Ioc.Dependencies.AutoMapper.MapperConfigurationBuilder().CreateMapper();

            var commentServiceMock = new Mock<ICommentService>();

            var dto = CreateCommentDtoFixture.Generate(1).First();

            var entity = mapper.Map<CreateCommentDto, Comment>(dto);

            var viewModel = mapper.Map<Comment, CommentViewModel>(entity);

            commentServiceMock.Setup(service => service.Post(dto)).ReturnsAsync(viewModel);

            // Act
            var response = await new CommentController(commentServiceMock.Object).Post(dto);

            // Assert
            commentServiceMock.Verify(service => service.Post(dto), Times.Once);

            var okObjectResult = Assert.IsType<CreatedResult>(response.Result);

            Assert.Equal(viewModel, okObjectResult.Value);
        }

        [Fact]
        public async Task Put_Updates_And_Returns_NoContent()
        {
            // Arrange
            var commentServiceMock = new Mock<ICommentService>();

            var dto = UpdateCommentDtoFixture.Generate(1).First();

            commentServiceMock.Setup(service => service.Put(dto)).Returns(Task.CompletedTask);

            // Act
            var response = await new CommentController(commentServiceMock.Object).Put(dto);

            // Assert
            commentServiceMock.Verify(service => service.Put(dto), Times.Once);

            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Delete_Deletes_And_Returns_NoContent()
        {
            // Arrange
            var commentServiceMock = new Mock<ICommentService>();

            var commentId = Guid.NewGuid();

            commentServiceMock.Setup(service => service.Delete(commentId)).Returns(Task.CompletedTask);

            // Act
            var response = await new CommentController(commentServiceMock.Object).Delete(commentId);

            // Assert
            commentServiceMock.Verify(service => service.Delete(commentId), Times.Once);

            Assert.IsType<NoContentResult>(response);
        }
    }
}