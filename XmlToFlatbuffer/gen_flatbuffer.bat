echo ׼����ʼ���ɱ��ṹ�ļ�

set TOOL_HOME_PATH=%cd%
echo %TOOL_HOME_PATH%
cd..
cd..
set PROJECT_WORK_PATH=%cd%
cd "%TOOL_HOME_PATH%"

echo ����Ŀ���ļ���
set DestTableFolder=%PROJECT_WORK_PATH%\Client\Assets\GameMain\PackageRes\DataTables
set DestLuaTableFolder=%PROJECT_WORK_PATH%\Client\Assets\GameMain\PackageRes\XLuaLogic\Data
set DestScriptFolder=%PROJECT_WORK_PATH%\Client\Assets\GameMain\Scripts\DataTable

tool\win\MakeTable.exe -f .\flatc.exe .\table\quest.xml .\gen

@pause