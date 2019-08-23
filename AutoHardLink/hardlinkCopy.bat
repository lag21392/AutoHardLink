@echo on

set pathuno = %1
set pathdos = %2 

cd %pathuno %
cd ..
XCOPY /E /I /C /Y %pathuno % %pathdos %
timeout 5
rd /S /Q %pathuno %
timeout 5
mklink /J %pathuno % %pathdos %
cd %~dp0