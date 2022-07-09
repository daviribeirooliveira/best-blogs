using System.Linq;
using Api.Tests.Fixtures;
using Api.Tests.Helpers;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Api.Tests.Models.Dtos
{
    public class UpdateCommentDtoTests
    {
        [Fact]
        public void UpdateCommentDto_ModelState_WithNullId_ShouldBeInvalid()
        {
            // Arrange
            var dto = UpdateCommentDtoFixture.Generate(1).First();

            dto.Id = null;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void UpdateCommentDto_ModelState_WithAuthorCharactersBiggerThan30_ShouldBeInvalid()
        {
            // Arrange
            var dto = UpdateCommentDtoFixture.Generate(1).First();

            dto.Author = new Faker().Random.String(31);

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void UpdateCommentDto_ModelState_WithContentCharactersBiggerThan120_ShouldBeInvalid()
        {
            // Arrange
            var dto = UpdateCommentDtoFixture.Generate(1).First();

            dto.Content = new Faker().Random.String(121);

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }
    }
}