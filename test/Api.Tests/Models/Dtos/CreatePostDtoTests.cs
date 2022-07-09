using System.Linq;
using Api.Tests.Fixtures;
using Api.Tests.Helpers;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Api.Tests.Models.Dtos
{
    public class CreatePostDtoTests
    {
        [Fact]
        public void CreatePostDto_ModelState_WithNullTitle_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreatePostDtoFixture.Generate(1).First();

            dto.Title = null;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreatePostDto_ModelState_WithEmptyTitle_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreatePostDtoFixture.Generate(1).First();

            dto.Title = string.Empty;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreatePostDto_ModelState_WithTitleCharactersBiggerThan30_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreatePostDtoFixture.Generate(1).First();

            dto.Title = new Faker().Random.String(31);

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreatePostDto_ModelState_WithNullContent_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreatePostDtoFixture.Generate(1).First();

            dto.Content = null;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreatePostDto_ModelState_WithEmptyContent_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreatePostDtoFixture.Generate(1).First();

            dto.Content = string.Empty;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreatePostDto_ModelState_WithContentCharactersBiggerThan1201_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreatePostDtoFixture.Generate(1).First();

            dto.Content = new Faker().Random.String(1201);

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }
    }
}