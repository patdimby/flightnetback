using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

public static class AirlineExtensions
{
    public static AirlineDto ToDto(this Airline airline)
    {
        return new AirlineDto(airline.Id, airline.Name, airline.State, airline.DeletedFlag);
    }
}

public record AirlineDto(int Id, string Name, State State, int DeletedFlag);

/// <summary>
///     The airline.
/// </summary>
[Table("Airlines")]
public class Airline : DeleteEntity<int>
{
    public Airline()
    {
    }

    public Airline(AirlineDto dto)
    {
        Copy(dto);
    }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    [Required(ErrorMessage = "Airline name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    [Column("name")]
    [JsonProperty(PropertyName = "name")]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the status.
    /// </summary>
    [Required(ErrorMessage = "State must be given.")]
    [Column("state")]
    [JsonProperty(PropertyName = "state")]
    public State State { get; set; } = State.Active;

    /// <summary>
    ///     Gets or sets the deleted flag.
    /// </summary>
    [Column("flag")]
    [JsonProperty(PropertyName = "flag")]
    public int DeletedFlag { get; set; }

    public void Copy(AirlineDto dto)
    {
        Id = dto.Id > 0 ? dto.Id : 0;
        Name = dto.Name;
        State = dto.State;
        DeletedFlag = dto.DeletedFlag;
    }
}
