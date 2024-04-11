using Flight.Domain.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Core.Entities
{
    /// <summary>
    /// The entity base.
    /// </summary>
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }
    }
}