@echo off

echo 准备开始生成表格结构文件

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
set PROJECT_WORK_PATH=%cd%
cd "%TOOL_HOME_PATH%"

echo 设置表格源文件夹
set SrcTableFolder=%PROJECT_WORK_PATH%\project\Assets\Main\DataTable

tool\win\MakeTable.exe -p %SrcTableFolder% .\gen

pause

@echo on