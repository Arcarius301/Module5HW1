using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module5HW1.Models;

namespace Module5HW1.Services.Abstractions
{
    public interface IResourceService
    {
        public Task<ListResourcesResponse?> GetResources();
        public Task<SingleResourceResponse?> GetResource(int id);
    }
}
