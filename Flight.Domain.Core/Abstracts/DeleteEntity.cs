using Flight.Domain.Core.Interfaces;

namespace Flight.Domain.Core.Entities
{
    /// <summary>
    /// The delete entity.
    /// </summary>
    public abstract class DeleteEntity<TKey> : EntityBase<TKey>, IDeleteEntity<TKey>
    {
        /// <summary>
        /// Gets or sets a value indicating whether is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}