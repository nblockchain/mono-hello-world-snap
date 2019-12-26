#!/usr/bin/env bash
set -euxo pipefail

make
mono src/bin/clr/monocurl.exe $1
