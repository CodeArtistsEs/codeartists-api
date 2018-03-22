using System.Collections.Generic;
using codeartistsapi.Models;

namespace codeartistsapi.Data.Repositories
{
    public interface INewsRepository 
    {
        IEnumerable<News> FindAll();
    }
}