#!/usr/bin/env bash
set -euo pipefail

rm -rf nupkg
mkdir nupkg

dotnet tool restore

pushd ./src/Blobfish
sudo chmod +x ./build.sh
./build.sh "$@"
popd