using AutoMapper;
using Flight.Application.Interfaces;
using Flight.Application.Results;
using Flight.Domain.Core.Abstracts;
using Flight.Domain.Interfaces;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Flight.Application.Applications;
/// <summary>
/// The generic application.
/// </summary>

public abstract class GenericApplication : Notifiable<Notification>, IGenericApplication<DeleteEntity<int>>
{
    protected IMapper Mapper;
    protected IGenericRepository<DeleteEntity<int>> Repository;

    /// <summary>
    ///     Deletes the async.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <returns>A Task.</returns>
    public async Task<Result> DeleteAsync(int id)
    {
        try
        {
            await Repository.DeleteAsync(id);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                return Result.Error(new ReadOnlyCollection<Notification>(new List<Notification>
                {
                    new(nameof(DeleteEntity<int>.Id), ex.InnerException.Message ?? ex.Message)
                }));
        }

        return null;
    }

    /// <summary>
    /// Gets the async.
    /// </summary>
    /// <returns>A Task.</returns>
    public async Task<Result<IEnumerable<DeleteEntity<int>>>> GetAsync()
    {
        var alls = await Repository.SelectAllAsync();

        return alls != null
            ? Result<IEnumerable<DeleteEntity<int>>>.Ok(Mapper.Map<IEnumerable<DeleteEntity<int>>>(alls))
            : null;
    }

    /// <summary>
    /// Gets the by id async.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <returns>A Task.</returns>
    public async Task<Result<DeleteEntity<int>>> GetByIdAsync(int id)
    {
        var item = await Repository.GetByIdAsync(id);
        return item != null ? Result<DeleteEntity<int>>.Ok(Mapper.Map<DeleteEntity<int>>(item)) : null;
    }

    /// <summary>
    /// Posts the async.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task.</returns>
    public async Task<Result> PostAsync(DeleteEntity<int> entity)
    {
        if (!IsValid)
            return Result.Error(Notifications);

        try
        {
            await Repository.AddAsync(Mapper.Map<DeleteEntity<int>>(entity));

            return Result.Ok();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                return Result.Error(new ReadOnlyCollection<Notification>(new List<Notification>
                {
                    new(nameof(DeleteEntity<int>.Id), ex.InnerException.Message ?? ex.Message)
                }));
        }

        return null;
    }

    /// <summary>
    /// Puts the async.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task.</returns>
    public async Task<Result> PutAsync(DeleteEntity<int> entity)
    {
        try
        {
            var old = await Repository.GetByIdAsync(entity.Id);
            await Repository.UpdateAsync(old, Mapper.Map<DeleteEntity<int>>(entity));

            return Result.Ok();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                return Result.Error(new ReadOnlyCollection<Notification>(new List<Notification>
                {
                    new(nameof(DeleteEntity<int>.Id), ex.InnerException.Message ?? ex.Message)
                }));
        }

        return null;
    }
}