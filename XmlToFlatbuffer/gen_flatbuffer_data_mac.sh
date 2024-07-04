echo "start generation table "
TOOL_HOME_PATH=$(cd `dirname $0`;pwd)
echo ${TOOL_HOME_PATH}
DATA_TABLE_PATH=$(cd `dirname ${TOOL_HOME_PATH}`;pwd)
DATA_TABLE_PATH=$(cd `dirname ${DATA_TABLE_PATH}`;pwd)

echo "set table source dir"
SrcTableFolder=${DATA_TABLE_PATH}/XML

echo "set project target dir"
DestTableFolder=${DATA_TABLE_PATH}/Tables
DestTableIdsFolder=${DATA_TABLE_PATH}/Tables/ids
DestScriptFolder=${DATA_TABLE_PATH}/Code
DestFlatbufferFolder=${DATA_TABLE_PATH}/Code/flatbuffer
DestGenCodeFolder=${DATA_TABLE_PATH}/Code/genarate
DestExtendCodeFolder=${DATA_TABLE_PATH}/Code/extend

echo "set template dir"
TempFBSFolder=${TOOL_HOME_PATH}/gen/fbs
TempBinTableFolder=${TOOL_HOME_PATH}/gen/data/binary
TempJsonTableFolder=${TOOL_HOME_PATH}/gen/data/json
TempIdsTableFolder=${TOOL_HOME_PATH}/gen/data/ids
TempCSharpFolder=${TOOL_HOME_PATH}/gen/code/csharp
TempExtendFolder=${TOOL_HOME_PATH}/gen/code/csharp/extend
TempLuaFolder=${TOOL_HOME_PATH}/gen/code/lua

echo "clean template dir"
rm -f -v ${TempFBSFolder}/*
rm -f -v ${TempBinTableFolder}/*
rm -f -v ${TempIdsTableFolder}/*
rm -f -v ${TempJsonTableFolder}/*
rm -f -v ${TempCSharpFolder}/flatbuffer/*
rm -f -v ${TempCSharpFolder}/genarate/*
#rm -f -v ${TempLuaFolder}/*

${TOOL_HOME_PATH}/tool/mac/MakeTable -d ${TOOL_HOME_PATH}/tool/mac/flatc ${SrcTableFolder}/ ${TOOL_HOME_PATH}/gen

if [ ! -d ${DestTableIdsFolder}/ ];then
  mkdir ${DestTableIdsFolder}
fi

if [ ! -d ${DestScriptFolder}/ ];then
  mkdir ${DestScriptFolder}
fi

if [ ! -d ${DestFlatbufferFolder}/ ];then
  mkdir ${DestFlatbufferFolder}
fi

if [ ! -d ${DestGenCodeFolder}/ ];then
  mkdir ${DestGenCodeFolder}
fi

if [ ! -d ${DestExtendCodeFolder}/ ];then
  mkdir ${DestExtendCodeFolder}
fi

cp -f -v ${TOOL_HOME_PATH}/gen/data/ids/*.bytes ${DestTableIdsFolder}/
cp -f -v ${TOOL_HOME_PATH}/gen/data/binary/*.bytes ${DestTableFolder}/
cp -f -v ${TOOL_HOME_PATH}/gen/code/csharp/*.cs ${DestScriptFolder}/
cp -f -v ${TOOL_HOME_PATH}/gen/code/csharp/flatbuffer/*.cs ${DestFlatbufferFolder}/
cp -f -v ${TOOL_HOME_PATH}/gen/code/csharp/genarate/*.cs ${DestGenCodeFolder}/

for file in ${TempExtendFolder}/*.cs; do
    filename=$(basename "$file")
    if [ ! -f ${DestExtendCodeFolder}/$filename ]; then
        cp -f -v "$file" ${DestExtendCodeFolder}/
    fi
done

echo "table handle complete"
