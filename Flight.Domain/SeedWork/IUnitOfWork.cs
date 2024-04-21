using System;
using System.Threading.Tasks;
using Flight.Domain.Interfaces;

namespace Flight.Domain.SeedWork;

/// <summary>
///     The unit of work.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    ///     repositories the.
    /// </summary>
    /// <returns>An IGenericRepository.</returns>
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

    /// <summary>
    ///     Start a new transaction.
    /// </summary>
    void BeginTransaction();

    /// <summary>
    ///     Save changes to our database.
    /// </summary>
    void Commit();

    /// <summary>
    ///     Rollback the database Transaction
    /// </summary>
    void Rollback();

    /// <summary>
    ///     DbContext Class SaveChanges method
    /// </summary>
    void Save();

    /// <summary>
    ///     Save changes asynchronously to our database.
    /// </summary>
    /// <returns>A Task.</returns>
    Task<int> CommitAsync();
}