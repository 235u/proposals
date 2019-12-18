using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleSearch
{
    public interface ILinkSearch
    {
        Task<IEnumerable<string>> FindLinksAsync(string q, int count);
    }
}
