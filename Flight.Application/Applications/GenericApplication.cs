using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using Flight.Application.Interfaces;
using Flight.Application.Results;
using Flight.Domain.Core.Abstracts;
using Flight.Domain.Interfaces;
using Flunt.Notifications;

namespace Flight.Application.Applications;

public abstract class GenericApplication : Notifiable<Notification>, IGenericApplication<DeleteEntity<int>>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<DeleteEntity<int>> _repository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GenericApplication" /> class.
    /// </summary>
    /// <param name="mapper">The mapper.</param>
    /// <param name="repository">The repository.</param>
    protected GenericApplication(IMapper mapper, IGenericRepository<DeleteEntity<int>> repository)
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
                    new(nameof(DeleteEntity<int>.Id), ex.InnerException.Message ?? ex.Message)
                }));
        }

        return null;
    }

    public async Task<Result<IEnumerable<DeleteEntity<int>>>> GetAsync()
    {
        var alls = await _repository.SelectAllAsync();

        return alls != null
            ? Result<IEnumerable<DeleteEntity<int>>>.Ok(_mapper.Map<IEnumerable<DeleteEntity<int>>>(alls))
            : null;
    }

    public async Task<Result<DeleteEntity<int>>> GetByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        return item != null ? Result<DeleteEntity<int>>.Ok(_mapper.Map<DeleteEntity<int>>(item)) : null;
    }

    public async Task<Result> PostAsync(DeleteEntity<int> entity)
    {
        if (!IsValid)
            return Result.Error(Notifications);

        try
        {
            await _repository.AddAsync(_mapper.Map<DeleteEntity<int>>(entity));

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

    public async Task<Result> PutAsync(DeleteEntity<int> entity)
    {
        try
        {
            var old = await _repository.GetByIdAsync(entity.Id);
            await _repository.UpdateAsync(old, _mapper.Map<DeleteEntity<int>>(entity));

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