@echo off
echo Downloading Cake...
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest http://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "$ProgressPreference = 'SilentlyContinue'; ./build.ps1