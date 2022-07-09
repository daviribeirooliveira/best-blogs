using System.Collections.Generic;
using Bogus;
using Model.Dtos;

namespace Api.Tests.Fixtures
{
    public static class UpdateCommentDtoFixture
    {
        public static IEnumerable<UpdateCommentDto> Generate(int quantity = 3)
        {
            var mocks = new Faker<UpdateCommentDto>()
                .StrictMode(true)
                .RuleFor(model => model.Id, faker => faker.Random.Guid())
                .RuleFor(model => model.Author, faker => faker.Person.FullName)
                .RuleFor(model => model.Content, faker => faker.Lorem.Paragraph())
                .Generate(quantity);

            return mocks;
        }
    }
}