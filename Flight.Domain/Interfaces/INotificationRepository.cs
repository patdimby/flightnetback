using Flight.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Domain.Interfaces
{
    /// <summary>
    /// The notification repositoryy.
    /// </summary>
    public interface INotificationRepositoryy<T> where T : class
    {
        /// <summary>
        /// Finds the all.
        /// </summary>
        /// <param name="trackChanges">If true, track changes.</param>
        /// <returns>An IQueryable.</returns>
        IQueryable<T> FindAll(bool trackChanges);
        /// <summary>
        /// Puts the async.
        /// </summary>
        /// <param name="old">The old.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>A Task.</returns>
        Task<Result> PutAsync(T old, T entity);
        /// <summary>
        /// Posts the async.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A Task.</returns>
        Task<Result> PostAsync(T entity);
        /// <summary>
        /// Selects the by id async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        Task<Result<T>> SelectByIdAsync(int id);
        /// <summary>
        /// Gets the all async.
        /// </summary>
        /// <returns>A Task.</returns>
        Task<Result<IEnumerable<T>>> GetAllAsync();
        /// <summary>
        /// Removes the async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        Task<Result> RemoveAsync(int id);
        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <returns>A Task.</returns>
        Task<Result<IEnumerable<T>>> GetAsync();
    }
}
