//-----------------------------------------------------------------------
// <copyright file="Config.cs" company="lanedirt">
// Copyright (c) lanedirt. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

namespace AliasVault.Client;

/// <summary>
/// Configuration class for the Client project with values loaded from appsettings.json.
/// </summary>
public class Config
{
    /// <summary>
    /// Gets or sets the admin password hash which is generated by install.sh and will be set
    /// as the default password for the admin user.
    /// </summary>
    public string ApiUrl { get; set; } = "false";

    /// <summary>
    /// Gets or sets the domains that the AliasVault server is listening for.
    /// Email addresses that client vault users use will be registered at the server
    /// to get exclusive access to the email address.
    /// </summary>
    public List<string> PrivateEmailDomains { get; set; } = [];

    /// <summary>
    /// Gets or sets the public email domains that are allowed to be used by the client vault users.
    /// </summary>
    public List<string> PublicEmailDomains { get; set; } =
    [
        "spamok.com",
        "solarflarecorp.com",
        "spamok.nl",
        "3060.nl",
        "landmail.nl",
        "asdasd.nl",
        "spamok.de",
        "spamok.com.ua",
        "spamok.es",
        "spamok.fr",
    ];
}