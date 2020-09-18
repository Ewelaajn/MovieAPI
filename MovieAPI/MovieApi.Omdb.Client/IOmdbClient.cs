using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Omdb.Client
{
    public interface IOmdbClient
    {
        Task<object> MovieByName(string title);
    }
}
