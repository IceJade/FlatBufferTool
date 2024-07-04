echo 准备开始自动生成表格文件

echo 工具目录
set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
set PROJECT_WORK_PATH=%cd%
cd "%TOOL_HOME_PATH%"

echo 设置表格源文件夹
set SrcTableFolder=%TOOL_HOME_PATH%\excel
echo %SrcTableFolder%

echo 设置目标文件夹
set DestTableFolder=%PROJECT_WORK_PATH%\project\Assets\Shelter\Config
set DestTableIdsFolder=%PROJECT_WORK_PATH%\project\Assets\Shelter\Config\ids
set DestScriptFolder=%PROJECT_WORK_PATH%\project\Assets\Shelter\Scripts\Config
set DestFlatbufferFolder=%PROJECT_WORK_PATH%\project\Assets\Shelter\Scripts\Config\flatbuffer
set DestGenCodeFolder=%PROJECT_WORK_PATH%\project\Assets\Shelter\Scripts\Config\genarate

echo 设置临时存放文件夹
set TempFBSFolder=%TOOL_HOME_PATH%\gen\fbs
set TempBinTableFolder=%TOOL_HOME_PATH%\gen\data\binary
set TempJsonTableFolder=%TOOL_HOME_PATH%\gen\data\json
set TempIdsTableFolder=%TOOL_HOME_PATH%\gen\data\ids
set TempCSharpFolder=%TOOL_HOME_PATH%\gen\code\csharp
set TempLuaFolder=%TOOL_HOME_PATH%\gen\code\lua

echo 清空所有临时文件夹
del /S /Q /F %TempFBSFolder%\*.*
del /S /Q /F %TempBinTableFolder%\*.*
del /S /Q /F %TempIdsTableFolder%\*.*
del /S /Q /F %TempJsonTableFolder%\*.*
del /S /Q /F %TempCSharpFolder%\*.*
del /S /Q /F %TempLuaFolder%\*.*

%TOOL_HOME_PATH%\tool\win\MakeTable.exe -f %TOOL_HOME_PATH%\tool\win\flatc.exe %SrcTableFolder% %TOOL_HOME_PATH%\gen

if not exist %DestTableIdsFolder% md %DestTableIdsFolder%
if not exist %DestFlatbufferFolder% md %DestFlatbufferFolder%

copy /Y %TOOL_HOME_PATH%\gen\data\ids\*.bytes %DestTableIdsFolder%\
copy /Y %TOOL_HOME_PATH%\gen\data\binary\*.bytes %DestTableFolder%\
copy /Y %TOOL_HOME_PATH%\gen\code\csharp\*.cs %DestScriptFolder%\
copy /Y %TOOL_HOME_PATH%\gen\code\csharp\flatbuffer\*.cs %DestFlatbufferFolder%
copy /Y %TOOL_HOME_PATH%\gen\code\csharp\genarate\*.cs %DestGenCodeFolder%

echo 表格处理完成 