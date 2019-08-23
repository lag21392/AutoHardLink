@echo off

set pathuno = %1
set pathdos = %2 

cd %pathuno %
cd ..
@echo on
XCOPY /E /I /C /Y %pathuno % %pathdos %
@echo off
timeout 5
@echo on
rd /S /Q %pathuno %
@echo off
timeout 5
@echo on
mklink /J %pathuno % %pathdos %
@echo off
cd %~dp0