using AutoMapper;
using Flight.Domain.Entities;
using Flight.Domain.Models;

namespace Flight.Application.Mapping
{
    /// <summary>
    /// The vehicle map.
    /// </summary>
    public class VehicleMap : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleMap"/> class.
        /// </summary>
        public VehicleMap()
        {
            CreateMap<Vehicle, VehicleModel>();
            CreateMap<VehicleInputModel, Vehicle>();
            CreateMap<VehicleModel, Vehicle>();
        }
    }
}