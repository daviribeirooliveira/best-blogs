using System.Linq;
using Api.Tests.Fixtures;
using Api.Tests.Helpers;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Api.Tests.Models.Dtos
{
    public class CreateCommentDtoTests
    {
        [Fact]
        public void CreateCommentDto_ModelState_WithNullAuthor_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreateCommentDtoFixture.Generate(1).First();

            dto.Author = null;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreateCommentDto_ModelState_WithEmptyAuthor_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreateCommentDtoFixture.Generate(1).First();

            dto.Author = string.Empty;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreateCommentDto_ModelState_WithAuthorCharactersBiggerThan30_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreateCommentDtoFixture.Generate(1).First();

            dto.Author = new Faker().Random.String(31);

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreateCommentDto_ModelState_WithNullContent_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreateCommentDtoFixture.Generate(1).First();

            dto.Content = null;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreateCommentDto_ModelState_WithEmptyContent_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreateCommentDtoFixture.Generate(1).First();

            dto.Content = string.Empty;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void CreateCommentDto_ModelState_WithContentCharactersBiggerThan120_ShouldBeInvalid()
        {
            // Arrange
            var dto = CreateCommentDtoFixture.Generate(1).First();

            dto.Content = new Faker().Random.String(121);

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }
    }
}