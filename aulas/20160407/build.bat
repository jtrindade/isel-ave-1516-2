@echo off

csc /t:library Log.cs RefLog.cs IntLog.cs

csc UseLog.cs /r:Log.dll