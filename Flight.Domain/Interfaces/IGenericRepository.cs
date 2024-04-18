using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Flight.Domain.Core.Abstracts;

namespace Flight.Domain.Interfaces;

/// <summary>
///     The repository.
/// </summary>
public interface IGenericRepository<T> where T : class
{
    /// <summary>
    ///     Asynchronous adds a generic T.
    /// </summary>
    /// <param name="entity">The entity.</param>
    Task<int> AddAsync(T entity);

    /// <summary>
    ///     Gets the all generics T.
    /// </summary>
    /// <returns>A list of generic T.</returns>
    Task<IEnumerable<T>> AllAsync();

    /// <summary>
    ///     Deletes the.
    /// </summary>
    /// <param name="entity">The entity.</param>
    Task<int> Delete(T entity);

    /// <summary>
    ///     Delete an entity from our repository.
    ///     <para>Examples:</para>
    ///     <para>_repository.Delete(entityList);</para>
    /// </summary>
    /// <param name="entities">List of entities to be deleted to our repository.</param>
    void Delete(IEnumerable<T> entities);

    /// <summary>
    ///     Delete an entity from our repository.
    ///     <para>Examples:</para>
    ///     <para>_repository.Delete(p=> p.UserId == userId);</para>
    /// </summary>
    /// <param name="predicate">Filter applied to our search.</param>
    void Delete(Expression<Func<T, bool>> predicate);

    /// <summary>
    ///     Deletes a generic T.
    /// </summary>
    /// <param name="entity">The entity.</param>
    Task<int> DeleteAsync(int id);

    /// <summary>
    ///     Gets the by condition.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns>An IQueryable.</returns>
    IQueryable<T> Get(Expression<Func<T, bool>> expression);

    /// <summary>
    ///     Gets a generic T by id.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <returns>A generic T.</returns>
    Task<T> GetByIdAsync(int id);

    /// <summary>
    ///     Method to insert a list of entities to our repository.
    ///     <para>Examples:</para>
    ///     <para>_repository.Insert(entityList);</para>
    /// </summary>
    /// <param name="entities">List of entities to be saved to our repository.</param>
    void Insert(IEnumerable<T> entities);

    /// <summary>
    ///     Saves the.
    /// </summary>
    /// <returns>A Task.</returns>
    Task<int> Save();

    /// <summary>
    ///     Select an entity from our repository using a filter.
    ///     <para>Examples:</para>
    ///     <para>_repository.Select(p=> p.UserId == 1);</para>
    ///     <para>_repository.Select(p=> p.UserName.Contains("John") == true);</para>
    /// </summary>
    /// <param name="predicate">Filter applied to our search.</param>
    /// <returns>Returns an entity from our repository.</returns>
    T Select(Expression<Func<T, bool>> predicate);

    /// <summary>
    ///     Select entities using pagination (take N).
    ///     <para>Examples:</para>
    ///     <para>_repository.SelectAllByPage(1, 20);</para>
    ///     <para>_repository.SelectAllByPage(pageNumber, quantityPerPage);</para>
    /// </summary>
    /// <param name="pageNumber">Page number.</param>
    /// <param name="quantity">Number of entities to select per page.</param>
    /// <returns>Returns entities from our repository.</returns>
    IList<T> SelectAllByPage(int pageNumber, int quantity);

    /// <summary>
    ///     Select an entity using it's primary keys as search criteria.
    ///     <para>Examples:</para>
    ///     <para>_repository.SelectByKey(userId);</para>
    ///     <para>_repository.SelectByKey(companyId, userId);</para>
    /// </summary>
    /// <param name="primaryKeys">Primary key properties of our entity.</param>
    /// <returns>Returns an entity from our repository.</returns>
    T SelectByKey(params object[] primaryKeys);

    /// <summary>
    ///     Updates the.
    /// </summary>
    /// <param name="entity">The entity.</param>
    Task<int> Update(T entity);

    /// <summary>
    ///     Method to update our repository using a list of entities.
    ///     <para>Examples:</para>
    ///     <para>_repository.Update(entityList);</para>
    /// </summary>
    /// <param name="entities">List of entities to be saved to our repository.</param>
    void Update(IEnumerable<T> entities);

    /// <summary>
    ///     Method to update specific properties of an entity.
    ///     <para>Examples:</para>
    ///     <para>_repository.Update(user, p => p.FirstName, p => p.LastName);</para>
    ///     <para>_repository.Update(user, p => p.Password);</para>
    /// </summary>
    /// <param name="entity">Entity instance to be saved to our repository.</param>
    /// <param name="properties">Array of expressions with the properties that will be changed.</param>
    void Update(T entity, params Expression<Func<T, object>>[] properties);

    /// <summary>
    ///     Selects the all async.
    /// </summary>
    /// <returns>A Task.</returns>
    Task<IEnumerable<T>> SelectAllAsync();

    /// <summary>
    ///     Updates the async.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task.</returns>
    Task<int> UpdateAsync(BaseEntity entity);
}