﻿using System;
using Flight.Domain.Core.Attributes;
using Flight.Domain.Core.Interfaces;

namespace Flight.Domain.Core.Abstracts;

public abstract class AuditEntity<TKey> : DeleteEntity<TKey>, IAuditEntity<TKey>
{
    /// <summary>
    ///     Gets or sets the created date.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    ///     Gets or sets the created by.
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    ///     Gets or sets the updated date.
    /// </summary>
    [UpdateGreaterThanCreate("CreatedDate")]
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    ///     Gets or sets the updated by.
    /// </summary>
    public string UpdatedBy { get; set; }
}