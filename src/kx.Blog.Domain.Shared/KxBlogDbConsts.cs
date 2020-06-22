using System;
using System.Collections.Generic;
using System.Text;

namespace kx.Blog.Domain.Shared
{
    public class KxBlogDbConsts
    {
        public static class DbTableName
        {
            public const string Posts = "Posts";
            public const string Categories = "Categories";
            public const string Tags = "Tags";
            public const string PostTags = "PostTags";
            public const string FriendLinks = "FriendLinks";
        }
    }
}
