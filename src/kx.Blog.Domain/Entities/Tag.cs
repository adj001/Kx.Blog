using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace kx.Blog.Domain.Entities
{
    /// <summary> 
    /// Tag 
    /// </summary> 
    public class Tag : Entity<int>
    {
        /// <summary> 
        /// 标签名称 
        /// </summary> 
        public string TagName { get; set; }
        /// <summary> 
        /// 展示名称 
        /// </summary> 
        public string DisplayName { get; set; }
    }
}
