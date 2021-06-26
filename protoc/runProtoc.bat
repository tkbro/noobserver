@rem: %1 = $(Configuration)

@echo off

protoc.exe -I=%~dp0 --csharp_out=%~dp0generated/ %~dp0.proto/sample.proto
::echo %~dp0
::echo %~dp0generated
::echo .proto/sample.proto

set GENERATOR_ERROR=%ERRORLEVEL%

if %GENERATOR_ERROR% NEQ 0 GOTO :error

@echo on

exit /B

:error
echo //error: call runProto.bat exited with error.

@echo on
EXIT /B -1