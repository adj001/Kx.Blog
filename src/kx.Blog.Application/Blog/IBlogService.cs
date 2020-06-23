using kx.Blog.Application.Contracts.Blog;
using kx.Blog.Domain.Entities;
using kx.Blog.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kx.Blog.Application.Blog
{
    public interface IBlogService
    {
        Task<ServiceResult<string>> InsertPostAsync(PostDto dto);

        Task<ServiceResult> DeletePostAsync(int id);

        Task<ServiceResult<string>> UpdatePostAsync(int id,PostDto dto);

        Task<ServiceResult<PostDto>> GetPostAsync(int id);

    }
}
