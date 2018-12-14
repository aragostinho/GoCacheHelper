using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCacheHelper.Service
{
    public interface IGoCache
    {
        GoCacheResponse Remove(string url);
        GoCacheResponse Remove(string[] url);
        bool IsCached(string url);

    }
}
