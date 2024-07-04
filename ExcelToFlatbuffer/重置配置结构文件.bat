@echo off

echo 准备开始生成表格结构文件

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
set PROJECT_WORK_PATH=%cd%
cd "%TOOL_HOME_PATH%"

echo 设置表格源文件夹
set SrcTableFolder=%TOOL_HOME_PATH%\excel
echo %SrcTableFolder%

set filename=%date:~0,4%%date:~5,2%%date:~8,2%%time:~0,2%%time:~3,2%%time:~6,2%
set "filename=%filename: =0%"
::echo %filename%

echo 设置备份文件夹
set TempBackupFolder=%TOOL_HOME_PATH%\gen\backup\design\%filename%
echo %TempBackupFolder%

if not exist %TempBackupFolder% md %TempBackupFolder%

echo 开始备份表结构文件
copy /Y .\gen\design\*.txt %TempBackupFolder%\

echo 清空现有表结构文件
del /S /Q /F .\gen\design\*.*

tool\win\MakeTable.exe -p %SrcTableFolder% .\gen

pause

@echo on