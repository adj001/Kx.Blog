using kx.Blog.Application.Blog;
using kx.Blog.Application.Contracts.Blog;
using kx.Blog.ToolKits.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using static kx.Blog.Domain.Shared.KxBlogConsts;

namespace kx.Blog.HttpApi.Controllers
{
    [ApiExplorerSettings(GroupName = ApiGrouping.GroupNameV1)]
    [ApiController]
    [Route("[controller]")]
    public class BlogController : AbpController
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// 添加博客
        /// </summary>
        /// <param name="postDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ServiceResult<string>> InsertPostAsync([FromBody] PostDto postDto)
        {
            return await _blogService.InsertPostAsync(postDto);
        }

        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ServiceResult> DeletePostAsync([Required(ErrorMessage = "ID不能为空")] int id)
        {
            return await _blogService.DeletePostAsync(id);
        }

        /// <summary>
        /// 更新博客
        /// </summary>
        /// <param name="id">博客ID</param>
        /// <param name="postDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ServiceResult<string>> UpdatePostAsync([Required(ErrorMessage = "ID不能为空")] int id, [FromBody] PostDto postDto)
        {
            return await _blogService.UpdatePostAsync(id, postDto);
        }

        /// <summary>
        /// 查询博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResult<PostDto>> GetPostAsync([Required(ErrorMessage = "ID不能为空")] int id)
        {
            return await _blogService.GetPostAsync(id);
        }
    }
}
