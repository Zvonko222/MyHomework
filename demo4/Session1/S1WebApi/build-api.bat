@echo off
setlocal
set "MSB=%ProgramFiles%\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
set "PROJ=%~dp0WebApplication\WebApplication\WebApplication.csproj"
set "DLL=%~dp0WebApplication\WebApplication\bin\WebApplication.dll"

if not exist "%MSB%" (
    echo [ERROR] MSBuild not found:
    echo         %MSB%
    pause
    exit /b 1
)

echo ============================================
echo  Building WebApplication.csproj (Debug)
echo ============================================
echo.

"%MSB%" "%PROJ%" /t:Rebuild /p:Configuration=Debug /p:VisualStudioVersion=17.0 /v:m /nologo
set "RC=%ERRORLEVEL%"

echo.
if not "%RC%"=="0" (
    echo ===== BUILD FAILED  exit code %RC% =====
    echo Copy the error lines above and send them back.
    pause
    exit /b %RC%
)

echo ===== BUILD OK =====
dir "%DLL%" | findstr /i "WebApplication.dll"
echo.
echo Now run run-api.bat to start the Web Api.
pause
