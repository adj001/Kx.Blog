using kx.Blog.Application.Contracts.Blog;
using kx.Blog.Domain.Entities;
using kx.Blog.Domain.Repositories;
using kx.Blog.ToolKits.Base;
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

        public async Task<ServiceResult> DeletePostAsync(int id)
        {
            var result = new ServiceResult();
            await _postRepository.DeleteAsync(id);
            return result;
        }

        public async Task<ServiceResult<PostDto>> GetPostAsync(int id)
        {
            var result = new ServiceResult<PostDto>();
            var entity = await _postRepository.GetAsync(id);
            if (entity == null)
            {
                result.IsFailed("文章不存在");
                return result;
            }
            var dto = new PostDto
            {
                Title = entity.Title,
                Author = entity.Author,
                Url = entity.Url,
                Html = entity.Html,
                Markdown = entity.Markdown,
                CategoryId = entity.CategoryId,
                CreationTime = entity.CreationTime
            };
            result.IsSuccess(dto);
            return result;
        }

        public async Task<ServiceResult<string>> InsertPostAsync(PostDto dto)
        {
            var result = new ServiceResult<string>();
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
            if (post == null)
            {
                result.IsFailed("添加失败");
            }
            else
            {
                result.IsSuccess("添加成功");
            }
            return result;
        }

        public async Task<ServiceResult<string>> UpdatePostAsync(int id, PostDto dto)
        {
            var result = new ServiceResult<string>();
            var entity = await _postRepository.GetAsync(id);
            if (entity == null)
            {
                result.IsFailed("文章不存在");
                return result;
            }
            entity.Title = dto.Title;
            entity.Author = dto.Author;
            entity.Url = dto.Url;
            entity.Html = dto.Html;
            entity.Markdown = dto.Markdown;
            entity.CategoryId = dto.CategoryId;
            entity.CreationTime = dto.CreationTime;
            await _postRepository.UpdateAsync(entity);
            result.IsSuccess("更新成功");
            return result;
        }
    }
}
