using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flight.Domain.Core.Abstracts;
using Flight.Infrastructure.Interfaces;

namespace Flight.Application.Concrete;

public class Service(DeleteEntity<int> entity) : IService<DeleteEntity<int>>
{
    private DeleteEntity<int> _entity = entity;

    public Task<int> CreateAsync(DeleteEntity<int> entity)
    {
        throw new NotImplementedException();
    }

    public Task<(IEnumerable<DeleteEntity<int>> entities, string ids)> CreateCollectionAsync(
        IEnumerable<DeleteEntity<int>> entityCollection)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int Id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DeleteEntity<int>>> GetAllAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteEntity<int>> GetAsync(int Id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DeleteEntity<int>>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, DeleteEntity<int> entityForUpdate, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}