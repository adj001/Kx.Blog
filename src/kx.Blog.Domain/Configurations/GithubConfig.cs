using System;
using System.Collections.Generic;
using System.Text;

namespace kx.Blog.Domain.Configurations
{
    public class GithubConfig
    {
        /// <summary>
        /// GET请求，跳转GitHub登录界面，获取用户授权，得到code
        /// </summary>
        public static string ApiAuthorize = "https://github.com/login/oauth/authorize";

        /// <summary>
        /// POST请求，根据code得到access_token
        /// </summary>
        public static string ApiAccessToken = "https://github.com/login/oauth/access_token";

        /// <summary>
        /// GET请求，根据access_token得到用户信息
        /// </summary>
        public static string ApiUser = "https://github.com/user";

        /// <summary>
        /// 
        /// </summary>
        public static int UserId = AppSettings.GitHub.UserId;

        /// <summary>
        /// 
        /// </summary>
        public static string ClientId = AppSettings.GitHub.ClientId;

        /// <summary>
        /// 
        /// </summary>
        public static string ClientSecret = AppSettings.GitHub.ClientSecret;

        /// <summary>
        /// 
        /// </summary>
        public static string RedirectUri = AppSettings.GitHub.RedirectUri;

        /// <summary>
        /// 
        /// </summary>
        public static string ApplicationName = AppSettings.GitHub.ApplicationName;

    }
}
