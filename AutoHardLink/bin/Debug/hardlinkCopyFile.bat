@echo off

set pathuno = %1
set pathdos = %2 
set pathtres = %3
cd %pathuno %
cd ..
@echo on
XCOPY /E /f /C /Y %pathuno % %pathtres % 
@echo off
timeout 5
@echo on
del /Q %pathuno %
@echo off
timeout 5
@echo on
mklink %pathuno % %pathdos %
@echo off
cd %~dp0