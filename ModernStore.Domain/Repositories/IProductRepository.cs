using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ModernStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetAll();
        Product GetById(Guid id);
        IEnumerable<Product> GetListByIds(List<Guid> ids);
    }
}
