echo 准备开始自动生成表格文件

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
cd..
set PROJECT_WORK_PATH=%cd%
cd "%TOOL_HOME_PATH%"

echo 设置表格源文件夹
set SrcTableFolder=%PROJECT_WORK_PATH%\Genarate\XML

echo 设置缓存文件夹
set GenarateFolder=%PROJECT_WORK_PATH%\Genarate\.gen

tool\win\MakeTable.exe -sa .\tool\win\flatc.exe %SrcTableFolder% %GenarateFolder%

echo 资源处理完毕

pause