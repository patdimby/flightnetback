using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using Flight.Application.Interfaces;
using Flight.Application.Results;
using Flight.Domain.Core.Abstracts;
using Flight.Domain.Entities;
using Flight.Domain.Interfaces;
using Flunt.Notifications;

namespace Flight.Application.Applications;

/// <summary>
///     The vehicle application.
/// </summary>
public class BaseApplication : Notifiable<Notification>, IGenericApplication<BaseEntity>
{
    private readonly IMapper _mapper;

    private readonly IGenericRepository<BaseEntity> _repository;
    //public record Dto;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Application" /> class.
    /// </summary>
    /// <param name="mapper">The mapper.</param>
    /// <param name="Repository">The vehicle repository.</param>
    public BaseApplication(IMapper mapper, IGenericRepository<BaseEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    /// <summary>
    ///     Deletes the async.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <returns>A Task.</returns>
    public async Task<Result> DeleteAsync(int id)
    {
        try
        {
            await _repository.DeleteAsync(id);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                return Result.Error(new ReadOnlyCollection<Notification>(new List<Notification>
                {
                    new(nameof(BaseEntity.Id), ex.InnerException.Message ?? ex.Message)
                }));
        }

        return null;
    }

    /// <summary>
    ///     Gets the async.
    /// </summary>
    /// <returns>A Task.</returns>
    public async Task<Result<IEnumerable<BaseEntity>>> GetAsync()
    {
        var items = await _repository.SelectAllAsync();

        return items != null ? Result<IEnumerable<BaseEntity>>.Ok(_mapper.Map<IEnumerable<BaseEntity>>(items)) : null;
    }

    /// <summary>
    ///     Gets the by id async.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <returns>A Task.</returns>
    public async Task<Result<BaseEntity>> GetByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);

        return item != null ? Result<BaseEntity>.Ok(_mapper.Map<BaseEntity>(item)) : null;
    }

    /// <summary>
    ///     Posts the async.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task.</returns>
    public async Task<Result> PostAsync(BaseEntity entity)
    {
        if (!IsValid)
            return Result.Error(Notifications);

        try
        {
            await _repository.AddAsync(_mapper.Map<BaseEntity>(entity));

            return Result.Ok();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                return Result.Error(new ReadOnlyCollection<Notification>(new List<Notification>
                {
                    new(nameof(Vehicle.Id), ex.InnerException.Message ?? ex.Message)
                }));
        }

        return null;
    }

    /// <summary>
    ///     Puts the async.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task.</returns>
    public async Task<Result> PutAsync(BaseEntity entity)
    {
        try
        {
            await _repository.UpdateAsync(_mapper.Map<BaseEntity>(entity));

            return Result.Ok();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                return Result.Error(new ReadOnlyCollection<Notification>(new List<Notification>
                {
                    new(nameof(BaseEntity.Id), ex.InnerException.Message ?? ex.Message)
                }));
        }

        return null;
    }
}