---
layout: default
title: Create a new release
parent: Release
grand_parent: Miscellaneous
nav_order: 1
---

# Release Preparation Checklist

Follow the steps in the checklist below to prepare a new release.

## Versioning
- [ ] Update ./src/Shared/AliasVault.Shared.Core/AppInfo.cs and update major/minor/patch to the new version. This version will be shown in the client and admin app footer.
- [ ] Update ./install.sh `@version` in header if the install script has changed. This allows the install script to self-update when running the `./install.sh update` command on default installations.

## Docker Images
If docker containers have been added or removed:
- [ ] Verify that `.github/workflows/publish-docker-images.yml` contains references to all docker images that need to be published.
- [ ] Update `install.sh` and verify that the `images=()` array that takes care of pulling the images from the GitHub Container Registry is updated.

## Manual Testing (since v0.10.0+)
- [ ] Verify that the db migration from SQLite to PostgreSQL works. This needs to be tested manually until the SQLite support is removed. Test with: `./install.sh db-migrate` on an existing installation that has a SQLite database in `./database/AliasServerDb.sqlite`.

## Documentation
- [ ] Update /docs instructions if any changes have been made to the setup process
- [ ] Update README screenshots if applicable
- [ ] Update README current/upcoming features
