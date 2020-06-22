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
    }
}
