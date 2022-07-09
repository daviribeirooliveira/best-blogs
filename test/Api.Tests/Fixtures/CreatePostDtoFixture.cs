using System.Collections.Generic;
using Bogus;
using Model.Dtos;

namespace Api.Tests.Fixtures
{
    public static class CreatePostDtoFixture
    {
        public static IEnumerable<CreatePostDto> Generate(int quantity = 3)
        {
            var mocks = new Faker<CreatePostDto>()
                .StrictMode(true)
                .RuleFor(model => model.Title, faker => faker.Lorem.Sentence(3))
                .RuleFor(model => model.Content, faker => faker.Lorem.Paragraph())
                .Generate(quantity);

            return mocks;
        }
    }
}