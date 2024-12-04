---
layout: default
title: Basic Install
parent: Installation Guide
nav_order: 1
---

# Basic Install
The following guide will walk you through the steps to install AliasVault on your own server. Minimum experience with Docker and Linux is required.

{: .toc }
* TOC
{:toc}

---

## 1. Basic Installation
To get AliasVault up and running quickly, run the install script to pull pre-built Docker images. The install script will also configure the .env file and start the AliasVault containers. You can get up and running in less than 5 minutes.

### Hardware requirements
- Linux VM with root access (Ubuntu or RHEL based distros recommended)
- 1 vCPU
- 512MB RAM
- 16GB disk space
- Docker installed

### Installation steps
1. Download the install script to a directory of your choice. All AliasVault files and directories will be created in this directory.
```bash
curl -o install.sh https://raw.githubusercontent.com/lanedirt/AliasVault/main/install.sh
```
2. Make the install script executable.
```bash
chmod +x install.sh
```
3. Run the install script. This will create the .env file, pull the Docker images, and start the AliasVault containers. Follow the on-screen prompts to configure AliasVault.
```bash
./install.sh install
```
> **Note**: AliasVault binds to ports 80 and 443 by default. If you want to change the default AliasVault ports you can do so in the `.env` file. Afterwards re-run the `./install.sh install` command to restart the containers with the new port settings.

3. After the script completes, you can access AliasVault at:
  - Client: `https://localhost`
  - Admin: `https://localhost/admin`

---

## 2. SSL configuration
The default installation will create a self-signed SSL certificate and configure Nginx to use it.

You can however also use Let's Encrypt to generate valid SSL certificates and configure Nginx to use it. In order to make this work you will need the following:

- A public IPv4 address assigned to your server
- Port 80 and 443 on your server must be open and accessible from the internet
- A registered domain name with an A record pointing to your server's public IP address (e.g. mydomain.com)

### Steps

1. Run the install script with the `configure-ssl` option
```bash
./install.sh configure-ssl
```
2. Follow the prompts to configure Let's Encrypt.

### Reverting to self-signed SSL
If at any point you would like to revert to the self-signed SSL certificate, run the install script again with the `configure-ssl` option
and then in the prompt choose option 2.

---

## 3. Email Server Setup

AliasVault includes a built-in email server that can handle multiple custom domains for your aliases.

To set up the email server, you need the following:
- Public IPv4 address
- Open ports (25 and 587) in server firewall for SMTP traffic
- Access to DNS record management for your domain

### a) DNS Configuration
Configure the following DNS records for your domain:

| Name | Type | Priority | Content                   | TTL |
|------|------|----------|---------------------------|-----|
| mail | A    |          | `<your-server-public-ip>` | 3600 |
| @    | MX   | 10       | `mail.<your-domain>`      | 3600 |

> Note: Replace `<your-server-public-ip>` and `<your-domain>` with your actual values.

### b) Port Configuration
The email server requires the following ports to be open:
- Port 25: Standard SMTP (unencrypted)
- Port 587: SMTP with STARTTLS (encrypted)

#### Verifying Port Access
You can test if the SMTP ports are correctly configured using telnet:

```bash
# Test standard SMTP port
telnet <your-server-public-ip> 25

# Test secure SMTP port
telnet <your-server-public-ip> 587
```

If successful, you'll see a connection establishment message. Press Ctrl+C to exit the telnet session.

### c) Setting Up Email Domains

1. Run the email configuration script:
  ```bash
  ./install.sh configure-email
  ````
2. Follow the interactive prompts to:
    - Configure your domain(s)
    - Restart required services

3. Once configured, you can:
   - Create new aliases in the AliasVault client
   - Use your custom domain(s) for email addresses
     - Note: you can configure the default domain for new aliases in the AliasVault client in Menu > Settings > Email Settings > Default Email Domain
   - Start receiving emails on your aliases

{: .note }
Important: DNS propagation can take up to 24-48 hours. During this time, email delivery might be inconsistent.

If you encounter any issues, feel free to open an issue on the [GitHub repository](https://github.com/lanedirt/AliasVault/issues).

---

## 4. Troubleshooting

### Resetting the admin password
If you have lost your admin password, you can reset it by running the install script with the `reset-password` option. This will generate a new random password and update the .env file with it. After that it will restart the AliasVault containers to apply the changes.
```bash
./install.sh reset-password
```

### Verbose output
If you need more detailed output from the install script, you can run it with the `--verbose` option. This will print more information to the console.
```bash
./install.sh install --verbose
```

### No emails being received
If you are not receiving emails on your aliases, check the following:
- Verify DNS records are correctly configured
- Ensure ports 25 and 587 are accessible
- Check your server's firewall settings
- Verify that your ISP/hosting provider allows SMTP traffic