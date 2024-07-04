echo 准备开始自动生成表格文件

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
set DATA_TABLE_PATH=%cd%
cd "%TOOL_HOME_PATH%"

echo 设置表格源文件夹
set SrcTableFolder=%DATA_TABLE_PATH%\XML

echo 设置目标文件夹
set DestTableFolder=%DATA_TABLE_PATH%\Tables
set DestTableIdsFolder=%DATA_TABLE_PATH%\Tables\ids
set DestScriptFolder=%DATA_TABLE_PATH%\Code
set DestFlatbufferFolder=%DATA_TABLE_PATH%\Code\flatbuffer
set DestGenCodeFolder=%DATA_TABLE_PATH%\Code\genarate

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
:: del /S /Q /F %TempCSharpFolder%\*.*
:: del /S /Q /F %TempLuaFolder%\*.*

tool\win\MakeTable.exe -d .\tool\win\flatc.exe %SrcTableFolder% .\gen

if not exist %DestTableIdsFolder% md %DestTableIdsFolder%
if not exist %DestFlatbufferFolder% md %DestFlatbufferFolder%

copy /Y .\gen\data\ids\*.bytes %DestTableIdsFolder%\
copy /Y .\gen\data\binary\*.bytes %DestTableFolder%\
:: copy /Y .\gen\code\csharp\*.cs %DestScriptFolder%\
:: copy /Y .\gen\code\csharp\flatbuffer\*.cs %DestFlatbufferFolder%
:: copy /Y .\gen\code\csharp\genarate\*.cs %DestGenCodeFolder%

echo 表格处理完成 

pause