using Flunt.Notifications;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Core.Entities
{
    /// <summary>
    /// The base entity.
    /// </summary>
    public class BaseEntity : Notifiable<Notification>
    {
        /// <summary>
        /// Date creation of entity.
        /// </summary>
        [Column("Created")]
        protected DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Date where entity is modified
        /// </summary>
        [Column("Updated")]
        protected DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Before the update.
        /// </summary>
        public void BeforeUpdate()
        {
            ModifiedDate = DateTime.UtcNow;
        }
    }
}