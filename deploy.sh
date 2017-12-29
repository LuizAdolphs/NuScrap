#!/bin/bash

ApiKey=$1

nuget pack ./NuScrap.nuspec -Verbosity detailed

nuget push ./NuScrap.*.nupkg -Verbosity detailed -ApiKey $ApiKey
