using System;
using System.Collections.Generic;
using System.Text;

namespace kx.Blog.Domain.Shared
{
    public class KxBlogConsts
    {
        public const string DbTablePrefix = "Kx";


        /// <summary>
        /// 接口分组
        /// </summary>
        public static class ApiGrouping
        {
            /// <summary>
            /// 博客前台接口组
            /// </summary>
            public const string GroupNameV1 = "v1";

            /// <summary>
            /// 博客后台接口组
            /// </summary>
            public const string GroupNameV2 = "v2";

            /// <summary>
            /// 其他通用接口组
            /// </summary>
            public const string GroupNameV3 = "v3";

            /// <summary>
            /// JWT授权接口组
            /// </summary>
            public const string GroupNameV4 = "v4";
        }
    }
}
