using kx.Blog.Application.Contracts.Blog;
using kx.Blog.Domain.Entities;
using kx.Blog.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kx.Blog.Application.Blog.Impl
{
    public class BlogService : ServiceBase, IBlogService
    {
        private readonly IPostRepository _postRepository;

        public BlogService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
            return await Task.FromResult(true);
        }

        public async Task<PostDto> GetPostAsync(int id)
        {
            var entity = await _postRepository.GetAsync(id);
            if (entity == null)
            {
                throw new Exception($"不存在ID为{id}的博客记录");
            }
            return new PostDto
            {
                Title = entity.Title,
                Author = entity.Author,
                Url = entity.Url,
                Html = entity.Html,
                Markdown = entity.Markdown,
                CategoryId = entity.CategoryId,
                CreationTime = entity.CreationTime
            };
        }

        public async Task<bool> InsertPostAsync(PostDto dto)
        {
            var entity = new Post
            {
                Title = dto.Title,
                Author = dto.Author,
                Url = dto.Url,
                Html = dto.Html,
                Markdown = dto.Markdown,
                CategoryId = dto.CategoryId,
                CreationTime = dto.CreationTime
            };
            var post = await _postRepository.InsertAsync(entity);
            return post != null;
        }

        public async Task<bool> UpdatePostAsync(int id, PostDto dto)
        {
            var entity = await _postRepository.GetAsync(id);
            if(entity==null)
            {
                throw new Exception($"不存在ID为{id}的博客记录");
            }
            entity.Title = dto.Title;
            entity.Author = dto.Author;
            entity.Url = dto.Url;
            entity.Html = dto.Html;
            entity.Markdown = dto.Markdown;
            entity.CategoryId = dto.CategoryId;
            entity.CreationTime = dto.CreationTime;
            await _postRepository.UpdateAsync(entity);
            return await Task.FromResult(true);
        }
    }
}
