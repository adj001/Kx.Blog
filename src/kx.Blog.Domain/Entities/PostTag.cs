using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace kx.Blog.Domain.Entities
{
    /// <summary> 
    /// PostTag 
    /// </summary> 
    public class PostTag : Entity<int>
    {
        /// <summary> 
        /// 文章Id 
        /// </summary> 
        public int PostId { get; set; }
        /// <summary> 
        /// 标签Id 
        /// </summary> 
        public int TagId { get; set; }
    }
}
