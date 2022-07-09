using System.Linq;
using Api.Tests.Fixtures;
using Api.Tests.Helpers;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Api.Tests.Models.Dtos
{
    public class UpdatePostDtoTests
    {
        [Fact]
        public void UpdatePostDto_ModelState_WithNullId_ShouldBeInvalid()
        {
            // Arrange
            var dto = UpdatePostDtoFixture.Generate(1).First();

            dto.Id = null;

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void UpdatePostDto_ModelState_WithTitleCharactersBiggerThan30_ShouldBeInvalid()
        {
            // Arrange
            var dto = UpdatePostDtoFixture.Generate(1).First();

            dto.Title = new Faker().Random.String(31);

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }

        [Fact]
        public void UpdatePostDto_ModelState_WithContentCharactersBiggerThan120_ShouldBeInvalid()
        {
            // Arrange
            var dto = UpdatePostDtoFixture.Generate(1).First();

            dto.Content = new Faker().Random.String(1201);

            // Act
            var isModelStateValid = ModelStateValidationHelper.Validate(dto);

            // Assert
            isModelStateValid.Should().BeFalse();
        }
    }
}