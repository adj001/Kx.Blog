using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace kx.Blog.Domain.Configurations
{
    /// <summary>
    /// appsettings.json配置文件数据读取类
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// 配置文件的根节点
        /// </summary>
        private static readonly IConfigurationRoot _configurationRoot;

        static AppSettings()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true);
            _configurationRoot = builder.Build();
        }

        public static string EnableDb => _configurationRoot["ConnectionStrings:Enable"];

        public static string ConnectionStrings => _configurationRoot.GetConnectionString(EnableDb);

        /// <summary>
        /// 
        /// </summary>
        public static string ApiVersion => _configurationRoot["ApiVersion"];

        public static class GitHub
        {
            public static int UserId => Convert.ToInt32(_configurationRoot["Github:UserId"]);
            public static string ClientId => _configurationRoot["Github:ClientId"];
            public static string ClientSecret => _configurationRoot["Github:ClientSecret"];
            public static string RedirectUri => _configurationRoot["Github:RedirectUri"];
            public static string ApplicationName => _configurationRoot["Github:ApplicationName"];
        }

        public static class JWT
        {
            public static string Domain = _configurationRoot["JWT:Domain"];
            public static string SecurityKey = _configurationRoot["JWT:SecurityKey "];
            public static int Expires = Convert.ToInt32(_configurationRoot["JWT:Expires"]);
        }
    }
}
