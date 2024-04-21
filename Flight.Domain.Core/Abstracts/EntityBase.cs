using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Interfaces;
using Flunt.Notifications;

namespace Flight.Domain.Core.Abstracts;

/// <summary>
///     The entity base.
/// </summary>
public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    /// <summary>
    ///     Gets or sets the notifiable.
    /// </summary>
    [NotMapped]
    public Notifiable<Notification> Notifiable { get; set; }

    /// <summary>
    ///     Gets or sets the id.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual TKey Id { get; set; }
}