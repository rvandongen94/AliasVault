---
layout: default
title: Uninstall
parent: Installation Guide
nav_order: 3
---

# Uninstall

To uninstall AliasVault, run the install script with the `uninstall` option. This will stop and remove the AliasVault containers, remove the Docker images, and delete the .env file.

### Steps
1. Run the install script with the `uninstall` option
```bash
./install.sh uninstall
```

> **Note:** This will not delete any data stored in the database. If you wish to delete all data, you should manually delete the `database` directory and the other directories created by AliasVault.