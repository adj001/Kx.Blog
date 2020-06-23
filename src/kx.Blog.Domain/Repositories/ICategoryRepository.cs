using kx.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace kx.Blog.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
