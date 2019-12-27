#!/usr/bin/env bash
set -euxo pipefail

sudo apt install -y snapd
sudo snap install --classic snapcraft

# workaround for latest version of snapcraft to work on GithubActions/AzureDevOps
sudo chown root:root /

snap --version
