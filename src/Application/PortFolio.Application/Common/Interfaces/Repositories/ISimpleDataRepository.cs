using System.Collections;
using System.Collections.Generic;

namespace PortFolio.Application.Common.Interfaces.Repositories;

public interface ISimpleDataRepository
{
    public IEnumerable<string> Get();
}