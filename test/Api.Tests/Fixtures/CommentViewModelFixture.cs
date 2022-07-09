using System;
using System.Collections.Generic;
using Bogus;
using Model.ViewModels;

namespace Api.Tests.Fixtures
{
    public static class CommentViewModelFixture
    {
        public static IEnumerable<CommentViewModel> Generate(int quantity = 3, Guid? postId = null)
        {
            var mocks = new Faker<CommentViewModel>()
                .StrictMode(true)
                .RuleFor(model => model.Id, faker => faker.Random.Guid())
                .RuleFor(model => model.PostId, faker => postId ?? faker.Random.Guid())
                .RuleFor(model => model.Author, faker => faker.Person.FullName)
                .RuleFor(model => model.Content, faker => faker.Lorem.Paragraph())
                .RuleFor(model => model.CreationDate, faker => faker.Date.Recent())
                .Generate(quantity);

            return mocks;
        }
    }
}