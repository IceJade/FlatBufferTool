@echo off

echo ׼����ʼ���ɱ��ṹ�ļ�

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
set PROJECT_WORK_PATH=%cd%
cd "%TOOL_HOME_PATH%"

echo ���ñ��Դ�ļ���
set SrcTableFolder=%PROJECT_WORK_PATH%\project\Assets\Main\DataTable

tool\win\MakeTable.exe -p %SrcTableFolder% .\gen

pause

@echo on