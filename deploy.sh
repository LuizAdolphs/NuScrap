#!/bin/bash

ApiKey=$1
Source=$2

nuget pack ./NuScrap.nuspec -Verbosity detailed

nuget push ./NuScrap.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source
