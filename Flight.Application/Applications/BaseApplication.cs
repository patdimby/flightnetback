using AutoMapper;
using Flight.Domain.Core.Abstracts;
using Flight.Domain.Entities;
using Flight.Domain.Interfaces;

namespace Flight.Application.Applications;

/// <summary>
///     The base application.
/// </summary>
public class BaseApplication : GenericApplication
{
    private IMapper mapper;
    private IGenericRepository<City> repository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BaseApplication" /> class.
    /// </summary>
    /// <param name="mapper">The mapper.</param>
    /// <param name="repository">The repository.</param>
    public BaseApplication(IMapper mapper, IGenericRepository<DeleteEntity<int>> repository)
    {
        Mapper = mapper;
        Repository = repository;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="BaseApplication" /> class.
    /// </summary>
    /// <param name="mapper">The mapper.</param>
    /// <param name="repository">The repository.</param>
    public BaseApplication(IMapper mapper, IGenericRepository<City> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
}