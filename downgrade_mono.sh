#!/usr/bin/env bash
set -euxo pipefail

sudo apt -y install fsharp
git submodule update --init
./downgradeMono.fsx
