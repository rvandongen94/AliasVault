//-----------------------------------------------------------------------
// <copyright file="Config.cs" company="lanedirt">
// Copyright (c) lanedirt. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

namespace AliasVault.TaskRunner;

/// <summary>
/// Configuration class for the TaskRunner with values loaded from appsettings.json file.
/// </summary>
public class Config
{
    /// <summary>
    /// TODO: update config properties to only use the ones that are needed for TaskRunner.
    /// TOOD: If none are needed, remove this class.
    /// Gets or sets whether TLS is enabled for the SMTP service.
    /// </summary>
    public string SmtpTlsEnabled { get; set; } = "false";

    /// <summary>
    /// Gets or sets the domains that the SMTP service is listening for.
    /// Domains not in this list will be rejected.
    /// </summary>
    public List<string> AllowedToDomains { get; set; } = [];
}
