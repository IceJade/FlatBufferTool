echo ��ʼ��������

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%

set FbsFolder=%TOOL_HOME_PATH%\gen\fbs
echo %FbsFolder%

echo ��������Դ·��
set DataFolder=%TOOL_HOME_PATH%\gen\bytes
echo %DataFolder%

echo ���õ���·��
set OutputFolder=%TOOL_HOME_PATH%\gen\output
echo %OutputFolder%

if not exist %OutputFolder% md %OutputFolder%

%TOOL_HOME_PATH%\tool\win\MakeTable.exe -json %TOOL_HOME_PATH%\tool\win\flatc.exe %FbsFolder% %DataFolder% %OutputFolder%

echo �������