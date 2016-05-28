@echo off

echo.
echo =================
echo Building Prog.dll
echo =================
echo.

ilasm /dll Prog.il

echo.
echo ==================
echo Verifying Prog.dll
echo ==================
echo.

peverify Prog.dll

echo.
echo ====================
echo Building UseProg.exe
echo ====================
echo.

csc UseProg.cs /r:Prog.dll

echo.
echo =====================
echo Verifying UseProg.exe
echo =====================
echo.

peverify UseProg.exe
