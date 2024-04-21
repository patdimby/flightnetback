using Flight.Domain.Interfaces;
using Flight.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Threading.Tasks;
using Flight.Infrastructure.Contracts;

namespace Flight.Infrastructure.Data;

/// <summary>
///     The unit of work.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly FlightContext _context;
    private string _errorMessage = string.Empty;
    private Hashtable _repositories;
    private bool disposed = false;

    /// <summary>
    ///     Begins the transaction.
    /// </summary>
    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Commits the.
    /// </summary>
    public void Commit()
    {
        _context.SaveChanges();
    }

    /// <summary>
    ///     Commits the async.
    /// </summary>
    /// <returns>A Task.</returns>
    public Task<int> CommitAsync()
    {
        return _context.SaveChangesAsync();
    }

    /// <summary>
    ///     Disposes the.
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }

    /// <summary>
    ///     repositories the.
    /// </summary>
    /// <returns>An IGenericRepository.</returns>
    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        _repositories ??= new Hashtable();
        var Type = typeof(TEntity).Name;
        if (!_repositories.ContainsKey(Type))
        {
            var repositiryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(
                repositiryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(Type, repositoryInstance);
        }

        return (IGenericRepository<TEntity>)_repositories[Type];
    }

    /// <summary>
    ///     Rollbacks the.
    /// </summary>
    public void Rollback()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Saves the.
    /// </summary>
    public void Save()
    {
        try
        {
            //Calling DbContext Class SaveChanges method
            _context.SaveChanges();
        }
        catch (DbUpdateException dbEx)
        {
            _errorMessage = dbEx.Message;
            throw new Exception(_errorMessage, dbEx);
        }
    }
}