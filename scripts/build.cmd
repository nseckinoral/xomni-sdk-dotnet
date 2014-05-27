@ECHO OFF
SET CACHED_NUGET=%LocalAppData%\NuGet\NuGet.exe

IF EXIST %CACHED_NUGET% goto run
echo Downloading latest version of NuGet.exe...
IF NOT EXIST %LocalAppData%\NuGet md %LocalAppData%\NuGet
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest 'https://www.nuget.org/nuget.exe' -OutFile '%CACHED_NUGET%'"

:run
IF "%1" == "" (

  @powershell -NoProfile -ExecutionPolicy unrestricted -File "build.ps1" "-buildParams /p:Configuration=Release"
  
) else (

  @powershell -NoProfile -ExecutionPolicy unrestricted -File "build.ps1" -buildParams "/p:Configuration=%1%"
)