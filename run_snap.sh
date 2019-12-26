#!/usr/bin/env bash
set -euxo pipefail

sudo snap install --dangerous monocurl_0.1_amd64.snap
snap run monocurl $1
