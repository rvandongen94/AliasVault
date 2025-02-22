---
layout: default
title: Contributing
parent: Development
grand_parent: Miscellaneous
nav_order: 1
---

# Contributing
This document is a work-in-progress and will be expanded as time goes on. If you have any questions feel free to open a issue on GitHub.

Note: all instructions below are based on MacOS. If you are using a different operating system, you may need to adjust the commands accordingly.

## Getting Started
In order to contribute to this project follow these instructions to setup your local environment:

### 1. Clone the repository
```bash
git clone https://github.com/lanedirt/AliasVault.git
cd AliasVault
```

### 2. Copy pre-commit hook script to .git/hooks directory
{: .note }
All commits in this repo are required to contain a reference to a GitHub issue in the format of "your commit message (#123)" where "123" references the GitHub issue number.

The pre-commit hook script below will check the commit message before allowing the commit to proceed. If the commit message is invalid, the commit will be aborted.

```bash
# Copy the commit-msg hook script to the .git/hooks directory
cp .github/hooks/commit-msg .git/hooks/commit-msg

# Make the script executable
chmod +x .git/hooks/commit-msg
```

### 3. Install the latest version of .NET SDK 9
```bash
# Install .NET SDK 9

# On MacOS via brew:
brew install --cask dotnet-sdk

# On Windows via winget
winget install Microsoft.DotNet.SDK.9
```

### 4. Install dotnet CLI EF Tools
```bash
# Install dotnet EF tools globally
dotnet tool install --global dotnet-ef
# Include dotnet tools in your PATH
nano ~/.zshrc
# Add the following line to your .zshrc file
export PATH="$PATH:$HOME/.dotnet/tools"
# Start a new terminal and test that this command works:
dotnet ef
```

### 5. Install dev database
AliasVault uses PostgreSQL as its database. In order to run the project locally from Visual Studio / Rider you will need to install the dev database. You can do this by running the following command. This will start a separate PostgreSQL instance on port 5433 accessible via the `localhost:5433` address.

```bash
./install.sh configure-dev-db
```

After the database is running you can start the project from Visual Studio / Rider in run or debug mode and it should be able to connect to the dev database.

### 6. Run Tailwind CSS compiler when changing HTML files to update compiled CSS
```bash
# For Admin project (in the admin project directory)
npm run build:admin-css
# For Client project (in the client project directory)
npm run build:client-css
```

### 7. Install Playwright in order to locally run NUnit E2E (end-to-end) tests
```bash
# First install PowerShell for Mac (if you don't have it already)
brew install powershell/tap/powershell
# Install Playwright
dotnet tool install --global Microsoft.Playwright.CLI
# Run Playwright install script to download local browsers
# Note: make sure the E2E test project has been built at least once so the bin dir exists.
pwsh src/Tests/AliasVault.E2ETests/bin/Debug/net9.0/playwright.ps1 install
```

### 8. Create AliasVault.Client appsettings.Development.json
The WASM client app supports a development specific appsettings.json file. This appsettings file is optional but can override various options to make debugging easier.

1. Copy `wwwroot/appsettings.json` to `wwwroot/appsettings.Development.json`

Here is an example file with the various options explained:

```json
{
    "ApiUrl": "http://localhost:5092",
    "PrivateEmailDomains": ["example.tld"],
    "SupportEmail": "support@example.tld",
    "UseDebugEncryptionKey": "true",
    "CryptographyOverrideType" : "Argon2Id",
    "CryptographyOverrideSettings" : "{\"DegreeOfParallelism\":1,\"MemorySize\":1024,\"Iterations\":1}"
}
```

- **UseDebugEncryptionKey**
  - This setting will use a static encryption key so that if you login as a user you can refresh the page without needing to unlock the database again. This speeds up development when changing things in the WebApp WASM project. Note: the project needs to be run in "Development" mode for this setting to be used.

- **CryptographyOverrideType**
  - This setting allows overriding the default encryption type (Argon2id) with a different encryption type. This is useful for testing different encryption types without having to change code.

- **CryptographyOverrideSettings**
  - This setting allows overriding the default encryption settings (Argon2id) with different settings. This is useful for testing different encryption settings without having to change code. The default Argon2id settings are defined in the project as `Utilities/Cryptography/Cryptography.Client/Defaults.cs`. These default settings are focused on security but NOT performance. Normally for key derivation purposes the slower/heavier the algorithm the better protection against attackers. For production builds this is what we want, however in case of automated testing or debugging extra performance can be gained by tweaking (lowering) these settings.
```