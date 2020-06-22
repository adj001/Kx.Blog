using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace kx.Blog.Domain.Entities
{
    /// <summary> 
    /// FriendLink 
    /// </summary> 
    public class FriendLink : Entity<int>
    {
        /// <summary> 
        /// 标题 
        /// </summary> 
        public string Title { get; set; }
        /// <summary> 
        /// 链接 
        /// </summary> 
        public string LinkUrl { get; set; }
    }
}