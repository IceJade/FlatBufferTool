echo "start generation table "
TOOL_HOME_PATH=$(cd `dirname $0`;pwd)
echo ${TOOL_HOME_PATH}
DATA_TABLE_PATH=$(cd `dirname ${TOOL_HOME_PATH}`;pwd)
DATA_TABLE_PATH=$(cd `dirname ${DATA_TABLE_PATH}`;pwd)
PROJECT_WORK_PATH=$(cd `dirname ${DATA_TABLE_PATH}`;pwd)

echo "set table source dir"
SrcTableFolder=${PROJECT_WORK_PATH}/Genarate/XML

echo "set cache dir"
GenarateFolder=${PROJECT_WORK_PATH}/Genarate/.gen

${TOOL_HOME_PATH}/tool/mac/MakeTable -sa ${TOOL_HOME_PATH}/tool/mac/flatc ${SrcTableFolder}/ ${GenarateFolder}/

echo "resource handle complete"
