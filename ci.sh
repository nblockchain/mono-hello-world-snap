#!/usr/bin/env bash
set -euxo pipefail

./build_snap.sh

./build_and_run.sh $1

./run_snap.sh $1
