#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Model.Exceptions;
using Model.ViewModels;
using Repository.Interfaces;
using Service.Interfaces;

#endregion

namespace Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public CommentService(IMapper mapper, ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<CommentViewModel>> GetAll()
        {
            var entities = await _commentRepository.GetAll();

            var viewModels = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(entities);

            return viewModels;
        }

        public async Task<CommentViewModel> Get(Guid id)
        {
            var entity = await _commentRepository.Get(id);

            var viewModel = _mapper.Map<Comment, CommentViewModel>(entity);

            return viewModel;
        }

        public async Task<IEnumerable<CommentViewModel>> GetByPostId(Guid postId)
        {
            var entities = await _commentRepository.GetByPostId(postId);

            var viewModels = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(entities);

            return viewModels;
        }

        public async Task<CommentViewModel> Post(CreateCommentDto comment)
        {
            if (comment?.PostId is null)
                throw new CustomValidationException(new Dictionary<string, string[]>
                    { { "PostId", new[] { "The PostId field is required." } } });

            var exists = await _postRepository.Exists(comment.PostId.Value);

            if (!exists)
                throw new CustomValidationException(new Dictionary<string, string[]>
                    { { "PostId", new[] { $"Post with Id: {comment.PostId} was not found." } } });

            var model = _mapper.Map<CreateCommentDto, Comment>(comment);

            var entity = await _commentRepository.Create(model);

            var viewModel = _mapper.Map<Comment, CommentViewModel>(entity);

            return viewModel;
        }

        public async Task Put(UpdateCommentDto comment)
        {
            if (comment?.Id is null)
                throw new CustomValidationException(new Dictionary<string, string[]>
                    { { "Id", new[] { "The Id field is required." } } });

            var entity = await _commentRepository.Get(comment.Id.Value);

            _mapper.Map(comment, entity);

            await _commentRepository.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            await _commentRepository.Delete(id);
        }
    }
}