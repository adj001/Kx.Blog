using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kx.Blog.Application.HelloWorld
{
    public class HelloWorldService : ServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World !!!";
        }
    }
}
