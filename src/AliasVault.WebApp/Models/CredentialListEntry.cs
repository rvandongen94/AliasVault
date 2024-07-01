//-----------------------------------------------------------------------
// <copyright file="CredentialListEntry.cs" company="lanedirt">
// Copyright (c) lanedirt. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

namespace AliasVault.WebApp.Models;

/// <summary>
/// Alias list entry model. This model is used to represent an alias in a list with simplified properties.
/// </summary>
public class CredentialListEntry
{
    /// <summary>
    /// Gets or sets the alias id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the alias logo byte array.
    /// </summary>
    public byte[]? Logo { get; set; }

    /// <summary>
    /// Gets or sets the alias service name.
    /// </summary>
    public string Service { get; set; } = null!;

    /// <summary>
    /// Gets or sets the alias create date.
    /// </summary>
    public DateTime CreateDate { get; set; }
}
