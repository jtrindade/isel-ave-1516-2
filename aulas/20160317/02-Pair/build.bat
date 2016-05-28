@echo off

echo.
echo =================
echo Building Pair1.cs
echo =================
echo.

csc Pair1.cs

echo.
echo =================
echo Building Pair2.il
echo =================
echo.

ilasm Pair2.il
