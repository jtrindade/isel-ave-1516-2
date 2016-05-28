@echo off

echo.
echo ===============
echo Building Gen.cs
echo ===============
echo.

csc Gen.cs

echo.
echo ===============
echo Running Gen.exe
echo ===============
echo.

Gen

echo.
echo ====================
echo Verifying GenAsm.exe
echo ====================
echo.

peverify GenAsm.exe
