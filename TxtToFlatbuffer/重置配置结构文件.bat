@echo off

echo ׼����ʼ���ɱ��ṹ�ļ�

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
set PROJECT_WORK_PATH=%cd%
cd "%TOOL_HOME_PATH%"

echo ���ñ��Դ�ļ���
set SrcTableFolder=%TOOL_HOME_PATH%\excel
echo %SrcTableFolder%

set filename=%date:~0,4%%date:~5,2%%date:~8,2%%time:~0,2%%time:~3,2%%time:~6,2%
set "filename=%filename: =0%"
::echo %filename%

echo ���ñ����ļ���
set TempBackupFolder=%TOOL_HOME_PATH%\gen\backup\design\%filename%
echo %TempBackupFolder%

if not exist %TempBackupFolder% md %TempBackupFolder%

echo ��ʼ���ݱ�ṹ�ļ�
copy /Y .\gen\design\*.txt %TempBackupFolder%\

echo ������б�ṹ�ļ�
del /S /Q /F .\gen\design\*.*

tool\win\MakeTable.exe -p %SrcTableFolder% .\gen

pause

@echo on