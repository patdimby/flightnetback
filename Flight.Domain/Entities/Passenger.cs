using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

public static class PassengerExtensions
{
    public static PassengerDto ToDto(this Passenger passenger)
    {
        return new PassengerDto(passenger.Id,
            passenger.Name,
            passenger.MiddleName,
            passenger.LastName,
            passenger.Email,
            passenger.Contact,
            passenger.Address);
    }
}

public record PassengerDto(
    int Id,
    string Name,
    string MiddleName,
    string LastName,
    string Email,
    string Contact,
    string Address);

/// <summary>
///     The passenger.
/// </summary>
[Table("Passengers")]
public class Passenger : DeleteEntity<int>
{
    public Passenger()
    {
    }

    public Passenger(PassengerDto dto)
    {
        Copy(dto);
    }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    [Required(ErrorMessage = "Employee name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    [Column("name")]
    [JsonProperty(PropertyName = "name")]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the middle name.
    /// </summary>
    [MaxLength(100, ErrorMessage = "Maximum length for middle name is 100 characters.")]
    [Column("middle_name")]
    [JsonProperty(PropertyName = "middle_name")]
    [DataType(DataType.Text)]
    public string MiddleName { get; set; } = "";

    /// <summary>
    ///     Gets or sets the last name.
    /// </summary>
    [MaxLength(100, ErrorMessage = "Maximum length for last name is 100 characters.")]
    [Column("last_name")]
    [JsonProperty(PropertyName = "last_name")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = "";

    /// <summary>
    ///     Gets or sets the email.
    /// </summary>

    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Required(ErrorMessage = "Email is required.")]
    [Column("email")]
    [JsonProperty(PropertyName = "email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = "";

    /// <summary>
    ///     Gets or sets the contact.
    /// </summary>
    [Required(ErrorMessage = "Contact is required.")]
    [Column("contact")]
    [JsonProperty(PropertyName = "contact")]
    [DataType(DataType.Text)]
    public string Contact { get; set; } = "";

    /// <summary>
    ///     Gets or sets the address.
    /// </summary>
    [Required(ErrorMessage = "Address is required.")]
    [Column("address")]
    [JsonProperty(PropertyName = "address")]
    [DataType(DataType.Text)]
    public string Address { get; set; } = "";

    /// <summary>
    ///     Gets or sets the sex.
    /// </summary>
    [Required(ErrorMessage = "Genre is required.")]
    [Column("genre")]
    [JsonProperty(PropertyName = "genre")]
    public Genre Sex { get; set; } = Genre.Unknown;

    public void Copy(PassengerDto dto)
    {
        Id = dto.Id > 0 ? dto.Id : 0;
        Name = dto.Name;
        MiddleName = dto.MiddleName;
        LastName = dto.LastName;
        Email = dto.Email;
        Contact = dto.Contact;
        Address = dto.Address;
    }
}