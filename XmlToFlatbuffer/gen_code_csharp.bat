echo ׼����ʼ���ɱ���������

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%

echo ����Դ�ļ���
set FBS_Folder=%TOOL_HOME_PATH%\gen\fbs

echo ���ô��������ļ���
set CodeFolder=%TOOL_HOME_PATH%\gen\code\csharp

echo ���֮ǰ���ɵĴ���
del /S /Q /F %CodeFolder%\*.*

flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/Achievement.fbs
flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/ActionExp.fbs
flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/ActiveAward.fbs
flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/ActivityTag.fbs
flatc.exe --csharp --gen-onefile -o %CodeFolder% .gen/fbs/ActivityType.fbs

@pause