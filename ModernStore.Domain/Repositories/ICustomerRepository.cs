using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetAll();
        Customer GetById(Guid id);
        Customer GetByUserId(Guid id);
        Customer GetByDocument(string document);
        void Update(Customer customer);
        void Save(Customer customer);
        bool DocumentExists(string document);
    }
}
