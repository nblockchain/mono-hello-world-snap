#!/usr/bin/env bash
set -euxo pipefail

sudo apt install -y snapd
sudo snap install --classic snapcraft

# workaround for latest version of snapcraft to work on GithubActions/AzureDevOps
sudo chown root:root /

snap --version
snapcraft --version

snapcraft --destructive-mode

sudo snap install --dangerous monocurl_0.1_amd64.snap
mono stage/usr/lib/monocurl/monocurl.exe $1
snap run monocurl $1
