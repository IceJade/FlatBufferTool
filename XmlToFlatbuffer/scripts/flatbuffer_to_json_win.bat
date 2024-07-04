echo 开始导出数据

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
set PROJECT_WORK_PATH=%cd%
cd "%TOOL_HOME_PATH%"

set FbsFolder=%TOOL_HOME_PATH%\gen\fbs

echo 设置数据源路径
::set DataFolder=%PROJECT_WORK_PATH%\project\Assets\StreamingAssets\Tables
set DataFolder=%TOOL_HOME_PATH%\gen\bytes

echo 设置导出路径
set OutputFolder=%TOOL_HOME_PATH%\gen\output

if not exist %OutputFolder% md %OutputFolder%

tool\win\MakeTable.exe -json .\tool\win\flatc.exe %FbsFolder% %DataFolder% %OutputFolder%

echo 导出完成