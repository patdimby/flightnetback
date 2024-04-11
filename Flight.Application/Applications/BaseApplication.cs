using AutoMapper;
using Flight.Application.Results;
using Flight.Domain.Core.Entities;
using Flight.Domain.Core.Interfaces;

using Flight.Domain.Interfaces;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flight.Application.Applications
{
    /// <summary>
    /// The vehicle application.
    /// </summary>
    public class BaseApplication : Notifiable<Notification>, IGenericApplication<BaseEntity>
    {
        private readonly IMapper _mapper;

        private readonly IGenericRepository<BaseEntity> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleApplication"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        public BaseApplication(IMapper mapper, IGenericRepository<BaseEntity> repository)
        {
            _mapper = mapper;

            _repository = repository;
        }

        /// <summary>
        /// Deletes the async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<Result> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <returns>A Task.</returns>
        public Task<Result<IEnumerable<BaseEntity>>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Result<BaseEntity>> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> PostAsync(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> PutAsync(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}