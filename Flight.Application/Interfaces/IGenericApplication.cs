using Flight.Application.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flight.Domain.Core.Interfaces
{
    /// <summary>
    /// The generic application.
    /// </summary>
    public interface IGenericApplication<T> where T : class
    {
        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <returns>A Task.</returns>
        public Task<Result<IEnumerable<T>>> GetAsync();

        /// <summary>
        /// Gets the by id async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<Result<T>> GetByIdAsync(int id);

        /// <summary>
        /// Posts the async.
        /// </summary>
        /// <param name="entity">The veichle.</param>
        /// <returns>A Task.</returns>
        public Task<Result> PostAsync(T entity);

        /// <summary>
        /// Puts the async.
        /// </summary>
        /// <param name="entity">The veichle.</param>
        /// <returns>A Task.</returns>
        public Task<Result> PutAsync(T entity);

        /// <summary>
        /// Deletes the async.
        /// </summary>
        /// <param name="id">The veichle id.</param>
        /// <returns>A Task.</returns>
        public Task<Result> DeleteAsync(int id);
    }
}