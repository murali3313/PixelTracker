@ECHO OFF
set b=tools\Nant\bin\nant /f:build\pixtracker.build -logger:NAnt.Core.ConsoleColorLogger -D:ConsoleColorLogger.info=Green -D:ConsoleColorLogger.error=Red -D:ConsoleColorLogger.warning=Yellow -logfile:b.log
if "%1"=="-f" goto find
%b% %*
@ECHO Developer Build Script Complete!
goto :EOF
:find
%b% show.targets |findstr /i "%2" 