﻿using Flight.Domain.Attributes;
using Flunt.Notifications;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Core.Entities
{
    /// <summary>
    /// The base entity.
    /// </summary>
    [NotMapped]
    public class BaseEntity : Notifiable<Notification>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Date creation of entity.
        /// </summary>
        [Column("Created")]
        protected DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Date where entity is modified
        /// </summary>
        [Column("Updated")]
        [UpdateGreaterThanCreate("CreatedDate")]
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