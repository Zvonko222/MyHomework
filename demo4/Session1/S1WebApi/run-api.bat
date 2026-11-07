@echo off
setlocal
set "IISEX=C:\Program Files\IIS Express\iisexpress.exe"
set "CFG=%~dp0WebApplication\.vs\S1WebApi\config\applicationhost.config"

if not exist "%IISEX%" (
    echo [ERROR] IIS Express not found: %IISEX%
    pause
    exit /b 1
)
if not exist "%CFG%" (
    echo [ERROR] applicationhost.config not found:
    echo         %CFG%
    echo Open the solution once in Visual Studio to recreate it.
    pause
    exit /b 1
)

echo ============================================
echo  Web Api   http://localhost:8081/api/vehicle?userId=1
echo  Keep this window open. Close it to stop.
echo ============================================
echo.

"%IISEX%" /site:WebApplication /config:"%CFG%"

echo.
echo IIS Express stopped.
pause
