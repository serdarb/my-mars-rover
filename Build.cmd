@echo off
set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
set solutionName=MarsRover
set solutionFolder=.\
set solutionFilePath="%solutionFolder%%solutionName%.sln"
set buildType=Debug
set returnErrorCode=true
set pause=true

echo.
echo =========================================================
echo   %solutionName%                                           
echo      Builds %solutionName%      
echo =========================================================
echo.

if "%1"=="/?" goto HELP

if not Exist %solutionFilePath% goto HELP

@REM  ----------------------------------------------------
@REM  If the first parameter is /q, do not pause
@REM  at the end of execution.
@REM  ----------------------------------------------------

if /i "%1"=="/q" (
 set pause=false
 SHIFT
)

@REM  ----------------------------------------------------
@REM  If the first or second parameter is /i, do not 
@REM  return an error code on failure.
@REM  ----------------------------------------------------

if /i "%1"=="/i" (
 set returnErrorCode=false
 SHIFT
)

@REM  ----------------------------------------------------
@REM  User can override default build type by specifiying
@REM  a parameter to batch file (e.g. %solutionName% Debug).
@REM  ----------------------------------------------------

if not "%1"=="" set buildType=%1

@REM  ------------------------------------------------
@REM  Shorten the command prompt for making the output
@REM  easier to read.
@REM  ------------------------------------------------
set savedPrompt=%prompt%
set prompt=*$g

@ECHO ----------------------------------------
@ECHO %solutionName% Build Started
@ECHO ----------------------------------------
@ECHO.

if "%DevEnvDir%"=="" (
	@ECHO ------------------------------------------
	@ECHO Setting build environment
	@ECHO ------------------------------------------
	@CALL "%VS120COMNTOOLS%\vsvars32.cmd" > NUL 
	@REM Remove LIB env var to work around known VS 2008 bug
	@SET Lib=
)

@ECHO.
@ECHO -------------------------------------------
@ECHO Building the %solutionName% assemblies
@ECHO -------------------------------------------

call %msBuildDir%\msbuild %solutionFilePath% /t:Rebuild /p:Configuration=%buildType%
@if errorlevel 1 goto :error

@ECHO.
@ECHO ----------------------------------------
@ECHO %solutionName%  Build Completed
@ECHO ----------------------------------------
@ECHO.

@REM  ----------------------------------------
@REM  Restore the command prompt and exit
@REM  ----------------------------------------
@goto :exit

@REM  -------------------------------------------
@REM  Handle errors
@REM
@REM  Use the following after any call to exit
@REM  and return an error code when errors occur
@REM
@REM  if errorlevel 1 goto :error	
@REM  -------------------------------------------
:error
if %returnErrorCode%==false goto exit

@ECHO An error occured in %solutionName%.cmd - %errorLevel%
if %pause%==true PAUSE
@exit errorLevel

:HELP
echo Usage: %solutionName% [/q] [/i] [build type] 
echo.
echo %solutionName% is to be executed in the directory where %solutionFilePath% resides
echo.

@REM  ----------------------------------------
@REM  The exit label
@REM  ----------------------------------------
:exit
if %pause%==true PAUSE

popd

set msBuildDir=
set solutionName=
set solutionFolder=
set solutionFilePath=
set buildType=
set returnErrorCode=
set pause=
set prompt=%savedPrompt%
set savedPrompt=

echo on