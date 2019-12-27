#!/usr/bin/env bash
set -euxo pipefail

snapcraft --version

snapcraft --destructive-mode
