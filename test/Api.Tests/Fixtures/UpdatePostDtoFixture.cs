using System.Collections.Generic;
using Bogus;
using Model.Dtos;

namespace Api.Tests.Fixtures
{
    public static class UpdatePostDtoFixture
    {
        public static IEnumerable<UpdatePostDto> Generate(int quantity = 3)
        {
            var mocks = new Faker<UpdatePostDto>()
                .StrictMode(true)
                .RuleFor(model => model.Id, faker => faker.Random.Guid())
                .RuleFor(model => model.Title, faker => faker.Lorem.Sentence(3))
                .RuleFor(model => model.Content, faker => faker.Lorem.Paragraph())
                .Generate(quantity);

            return mocks;
        }
    }
}