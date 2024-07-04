echo "start generation table "
TOOL_HOME_PATH=$(cd `dirname $0`;pwd)
echo ${TOOL_HOME_PATH}
PROJECT_WORK_PATH=$(cd `dirname ${TOOL_HOME_PATH}`;pwd)
PROJECT_WORK_PATH=$(cd `dirname ${PROJECT_WORK_PATH}`;pwd)

echo "set table source dir"
SrcTableFolder=${TOOL_HOME_PATH}/excel

echo "set project target dir"
DestTableFolder=${PROJECT_WORK_PATH}/project/Assets/Shelter/Config
DestTableIdsFolder=${PROJECT_WORK_PATH}/project/Assets/Shelter/Config/ids
DestScriptFolder=${PROJECT_WORK_PATH}/project/Assets/Shelter/Scripts/Config
DestFlatbufferFolder=${PROJECT_WORK_PATH}/project/Assets/Shelter/Scripts/Config/flatbuffer
DestGenCodeFolder=${PROJECT_WORK_PATH}/project/Assets/Shelter/Scripts/Config/genarate

echo "set template dir"
TempFBSFolder=${TOOL_HOME_PATH}/gen/fbs
TempBinTableFolder=${TOOL_HOME_PATH}/gen/data/binary
TempJsonTableFolder=${TOOL_HOME_PATH}/gen/data/json
TempIdsTableFolder=${TOOL_HOME_PATH}/gen/data/ids
TempCSharpFolder=${TOOL_HOME_PATH}/gen/code/csharp
TempLuaFolder=${TOOL_HOME_PATH}/gen/code/lua

echo "clean template dir"
rm -f -v ${TempFBSFolder}/*
rm -f -v ${TempBinTableFolder}/*
rm -f -v ${TempIdsTableFolder}/*
rm -f -v ${TempJsonTableFolder}/*
rm -f -v ${TempCSharpFolder}/flatbuffer/*
rm -f -v ${TempCSharpFolder}/genarate/*
#rm -f -v ${TempCSharpFolder}/*
rm -f -v ${TempLuaFolder}/*

${TOOL_HOME_PATH}/tool/mac/MakeTable -f ${TOOL_HOME_PATH}/tool/mac/flatc ${SrcTableFolder}/ ${TOOL_HOME_PATH}/gen

if [ ! -d ${DestTableIdsFolder}/ ];then
  mkdir ${DestTableIdsFolder}
fi

if [ ! -d ${DestFlatbufferFolder}/ ];then
  mkdir ${DestFlatbufferFolder}
fi

cp -f -v ${TOOL_HOME_PATH}/gen/data/ids/*.bytes ${DestTableIdsFolder}/
cp -f -v ${TOOL_HOME_PATH}/gen/data/binary/*.bytes ${DestTableFolder}/
cp -f -v ${TOOL_HOME_PATH}/gen/code/csharp/*.cs ${DestScriptFolder}/
cp -f -v ${TOOL_HOME_PATH}/gen/code/csharp/flatbuffer/*.cs ${DestFlatbufferFolder}/
cp -f -v ${TOOL_HOME_PATH}/gen/code/csharp/genarate/*.cs ${DestGenCodeFolder}/

echo "table handle complete"
