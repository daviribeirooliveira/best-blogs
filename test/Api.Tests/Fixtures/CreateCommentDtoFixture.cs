using System;
using System.Collections.Generic;
using Bogus;
using Model.Dtos;

namespace Api.Tests.Fixtures
{
    public static class CreateCommentDtoFixture
    {
        public static IEnumerable<CreateCommentDto> Generate(int quantity = 3, Guid? postId = null)
        {
            var mocks = new Faker<CreateCommentDto>()
                .StrictMode(true)
                .RuleFor(model => model.PostId, faker => postId ?? faker.Random.Guid())
                .RuleFor(model => model.Author, faker => faker.Person.FullName)
                .RuleFor(model => model.Content, faker => faker.Lorem.Paragraph())
                .Generate(quantity);

            return mocks;
        }
    }
}