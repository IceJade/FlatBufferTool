echo ׼����ʼ�Զ����ɱ���ļ�

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
cd..
set PROJECT_WORK_PATH=%cd%
cd "%TOOL_HOME_PATH%"

echo ���ñ��Դ�ļ���
set SrcTableFolder=%PROJECT_WORK_PATH%\Genarate\XML

echo ���û����ļ���
set GenarateFolder=%PROJECT_WORK_PATH%\Genarate\.gen

tool\win\MakeTable.exe -sa .\tool\win\flatc.exe %SrcTableFolder% %GenarateFolder%

echo ��Դ�������

pause