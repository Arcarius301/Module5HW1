using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1.Services.Abstractions
{
    public interface IResourceService
    {
        public Task<string> GetResources();
        public Task<string> GetResource(int id);
    }
}
