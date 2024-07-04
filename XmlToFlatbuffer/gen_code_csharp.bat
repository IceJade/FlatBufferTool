echo 准备开始生成表格解析代码

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%

echo 设置源文件夹
set FBS_Folder=%TOOL_HOME_PATH%\gen\fbs

echo 设置代码生成文件夹
set CodeFolder=%TOOL_HOME_PATH%\gen\code\csharp

echo 清空之前生成的代码
del /S /Q /F %CodeFolder%\*.*

flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/Achievement.fbs
flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/ActionExp.fbs
flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/ActiveAward.fbs
flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/ActivityTag.fbs
flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/ActivityType.fbs

@pause