echo "start generation json data"
TOOL_HOME_PATH=$(cd `dirname $0`;pwd)
echo ${TOOL_HOME_PATH}
PROJECT_WORK_PATH=$(cd `dirname ${TOOL_HOME_PATH}`;pwd)
PROJECT_WORK_PATH=$(cd `dirname ${PROJECT_WORK_PATH}`;pwd)

set FbsFolder=${TOOL_HOME_PATH}/gen/fbs

echo "set data source directory"
DataFolder=${PROJECT_WORK_PATH}/project/Assets/StreamingAssets/Tables

echo "set output directory"
OutputFolder=%TOOL_HOME_PATH%/gen/output

if [ ! -d ${OutputFolder}/ ];then
  mkdir ${OutputFolder}
fi

tool/mac/MakeTable -json ./tool/mac/flatc ${FbsFolder}/ ${DataFolder}/ ${OutputFolder}/

echo "to json data complete"