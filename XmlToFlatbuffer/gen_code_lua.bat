echo ׼����ʼ���ɱ���������

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%

echo ����Դ�ļ���
set FBS_Folder=%TOOL_HOME_PATH%\gen\fbs
set CodeFolder=%TOOL_HOME_PATH%\gen\code\lua

echo ���֮ǰ���ɵĴ���
del /S /Q /F %CodeFolder%\*.*

flatc.exe --lua -o %CodeFolder% .gen/fbs/Achievement.fbs
flatc.exe --lua -o %CodeFolder% .gen/fbs/ActionExp.fbs
flatc.exe --lua -o %CodeFolder% .gen/fbs/ActiveAward.fbs
flatc.exe --lua -o %CodeFolder% .gen/fbs/ActivityTag.fbs
flatc.exe --lua -o %CodeFolder% .gen/fbs/ActivityType.fbs

@pause