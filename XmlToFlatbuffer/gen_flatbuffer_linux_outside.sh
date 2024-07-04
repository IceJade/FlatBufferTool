echo "start generation table "
TOOL_HOME_PATH=$(cd `dirname $0`;pwd)
echo ${TOOL_HOME_PATH}
PROJECT_WORK_PATH=$(cd `dirname ${TOOL_HOME_PATH}`;pwd)
PROJECT_WORK_PATH=$(cd `dirname ${PROJECT_WORK_PATH}`;pwd)

echo "set table source dir"
SrcTableFolder=/flatbuffers/xmlfiles

echo "set template dir"
TempFBSFolder=${TOOL_HOME_PATH}/gen/fbs
TempBinTableFolder=${TOOL_HOME_PATH}/gen/data/binary
TempJsonTableFolder=${TOOL_HOME_PATH}/gen/data/json
TempIdsTableFolder=${TOOL_HOME_PATH}/gen/data/ids
TempCSharpFolder=${TOOL_HOME_PATH}/gen/code/csharp
TempLuaFolder=${TOOL_HOME_PATH}/gen/code/lua

# echo "clean template dir"
# rm -rf -v ${TempFBSFolder}/*
# rm -rf -v ${TempBinTableFolder}/*
# rm -rf -v ${TempIdsTableFolder}/*
# rm -rf -v ${TempJsonTableFolder}/*
# rm -rf -v ${TempCSharpFolder}/*
# rm -rf -v ${TempLuaFolder}/*

tool/linux/MakeTable -ov ./tool/linux/flatc ${SrcTableFolder}/ ./gen
