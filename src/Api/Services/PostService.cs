#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Services.Interfaces;
using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Model.Exceptions;
using Model.ViewModels;
using Repository.Interfaces;

#endregion

namespace Api.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostService(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostViewModel>> GetAll()
        {
            var entities = await _postRepository.GetAll();

            var viewModels = _mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(entities);

            return viewModels;
        }

        public async Task<PostViewModel> Get(Guid id)
        {
            var entity = await _postRepository.Get(id);

            var viewModel = _mapper.Map<Post, PostViewModel>(entity);

            return viewModel;
        }

        public async Task<PostViewModel> Post(CreatePostDto post)
        {
            if (post is null)
                throw new CustomValidationException(new Dictionary<string, string[]>
                    { { "Post", new[] { "Post is required." } } });

            var model = _mapper.Map<CreatePostDto, Post>(post);

            var entity = await _postRepository.Create(model);

            var viewModel = _mapper.Map<Post, PostViewModel>(entity);

            return viewModel;
        }

        public async Task Put(UpdatePostDto post)
        {
            if (post?.Id is null)
                throw new CustomValidationException(new Dictionary<string, string[]>
                    { { "Id", new[] { "The Id field is required." } } });

            var entity = await _postRepository.Get(post.Id.Value);

            _mapper.Map(post, entity);

            await _postRepository.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            await _postRepository.Delete(id);
        }
    }
}