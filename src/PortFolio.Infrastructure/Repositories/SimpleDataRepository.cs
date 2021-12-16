using System.Collections.Generic;
using PortFolio.Application.Common.Interfaces.Repositories;

namespace PortFolio.Infrastructure.Repositories
{
    public class SimpleDataRepository : ISimpleDataRepository
    {
        public IEnumerable<string> Get()
        {
            return new[] { "Data1", "Data2", "Data3" };
        }
    }
}