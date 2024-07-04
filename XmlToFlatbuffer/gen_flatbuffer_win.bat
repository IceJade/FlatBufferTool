echo 准备开始自动生成表格文件

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
set DATA_TABLE_PATH=%TOOL_HOME_PATH%
cd "%TOOL_HOME_PATH%"

echo 设置表格源文件夹
set SrcTableFolder=%DATA_TABLE_PATH%\XML

echo 设置目标文件夹
set DestTableFolder=%DATA_TABLE_PATH%\project\data\bytes
set DestTableIdsFolder=%DATA_TABLE_PATH%\project\data\ids
set DestScriptFolder=%DATA_TABLE_PATH%\project\code
set DestFlatbufferFolder=%DATA_TABLE_PATH%\project\code\flatbuffer
set DestGenCodeFolder=%DATA_TABLE_PATH%\project\code\genarate
set DestExtendCodeFolder=%DATA_TABLE_PATH%\project\code\extend

echo 设置临时存放文件夹
set TempFBSFolder=%TOOL_HOME_PATH%\gen\fbs
set TempBinTableFolder=%TOOL_HOME_PATH%\gen\data\binary
set TempJsonTableFolder=%TOOL_HOME_PATH%\gen\data\json
set TempIdsTableFolder=%TOOL_HOME_PATH%\gen\data\ids
set TempCSharpFolder=%TOOL_HOME_PATH%\gen\code\csharp
set TempExtendFolder=%TOOL_HOME_PATH%\gen\code\csharp\extend
set TempGenarateFolder=%TOOL_HOME_PATH%\gen\code\csharp\genarate
set TempFlatbufferFolder=%TOOL_HOME_PATH%\gen\code\csharp\flatbuffer
set TempLuaFolder=%TOOL_HOME_PATH%\gen\code\lua

echo 清空所有临时文件夹
del /S /Q /F %TempFBSFolder%\*.*
del /S /Q /F %TempBinTableFolder%\*.*
del /S /Q /F %TempIdsTableFolder%\*.*
del /S /Q /F %TempJsonTableFolder%\*.*
del /S /Q /F %TempCSharpFolder%\*.*
del /S /Q /F %TempLuaFolder%\*.*

tool\win\MakeTable.exe -f .\tool\win\flatc.exe %SrcTableFolder% .\gen

if not exist %DestTableFolder% md %DestTableFolder%
if not exist %DestTableIdsFolder% md %DestTableIdsFolder%
if not exist %DestScriptFolder% md %DestScriptFolder%
if not exist %DestFlatbufferFolder% md %DestFlatbufferFolder%
if not exist %DestGenCodeFolder% md %DestGenCodeFolder%
if not exist %DestExtendCodeFolder% md %DestExtendCodeFolder%

copy /Y %TempIdsTableFolder%\*.bytes %DestTableIdsFolder%\
copy /Y %TempBinTableFolder%\*.bytes %DestTableFolder%\
copy /Y %TempCSharpFolder%\*.cs %DestScriptFolder%\
copy /Y %TempFlatbufferFolder%\*.cs %DestFlatbufferFolder%\
copy /Y %TempGenarateFolder%\*.cs %DestGenCodeFolder%\
:: copy /Y %TempExtendFolder%\*.cs %DestExtendCodeFolder%\

for /R "%TempExtendFolder%" %%F in (*.cs) do (
    if not exist "%DestExtendCodeFolder%\%%~nxF" (
        copy /Y "%%F" "%DestExtendCodeFolder%\"
    )
)

del /Q /F %DestTableIdsFolder%\atlas_ids.bytes
del /Q /F %DestTableFolder%\atlas.bytes
del /Q /F %DestFlatbufferFolder%\DTatlas.cs
del /Q /F %DestGenCodeFolder%\AtlasTable.cs

del /Q /F %DestTableIdsFolder%\sprites_ids.bytes
del /Q /F %DestTableFolder%\sprites.bytes
del /Q /F %DestFlatbufferFolder%\DTsprites.cs
del /Q /F %DestGenCodeFolder%\SpritesTable.cs

echo 表格处理完成

pause