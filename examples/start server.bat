@echo off
title Fantasy Server
REM 路径下必须有Main.dll，/d：允许跨盘切换，%~dp0：当前bat文件所在的路径
REM cd /d %~dp0
cd /d C:\itsxwz\github\UnityUltimateFramework\Fantasy\examples\Bin\Debug\net8.0

where dotnet >nul 2>nul
if %errorlevel% neq 0 (
    echo 未检测到 dotnet 运行时，请先安装 .NET 8
    pause
    exit /b
)

echo Start Server...
REM 开发模式启动
dotnet Main.dll -m Develop -g 0
pause