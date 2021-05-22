using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raitorcours_server.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriesRepository Categories { get; }
        int Complete();
    }
}
