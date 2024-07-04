echo 准备开始生成表格解析代码

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%

echo 设置源文件夹
set FBS_Folder=%TOOL_HOME_PATH%\gen\fbs
set CodeFolder=%TOOL_HOME_PATH%\gen\code\lua

echo 清空之前生成的代码
del /S /Q /F %CodeFolder%\*.*

flatc.exe --lua -o %CodeFolder% .gen/fbs/Achievement.fbs
flatc.exe --lua -o %CodeFolder% .gen/fbs/ActionExp.fbs
flatc.exe --lua -o %CodeFolder% .gen/fbs/ActiveAward.fbs
flatc.exe --lua -o %CodeFolder% .gen/fbs/ActivityTag.fbs
flatc.exe --lua -o %CodeFolder% .gen/fbs/ActivityType.fbs

@pause