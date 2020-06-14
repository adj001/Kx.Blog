using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kx.Blog.Application.HelloWorld
{
    public class HelloWorldServeice : ServiceBase, IHelloWorldService
    {
        public async Task<string> HelloWorld()
        {
            return await Task.FromResult("Hello World !!!");
        }
    }
}
