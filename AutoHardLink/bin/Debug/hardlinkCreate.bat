@echo on

set pathuno = %1
set pathdos = %2 

cd %pathuno %
cd ..
rem XCOPY /E /I /C /Y %pathuno % %pathdos %
rd /S /Q %pathuno %
mklink /J %pathuno % %pathdos %
cd %~dp0