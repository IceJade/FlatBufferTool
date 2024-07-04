echo "start generation table "
TOOL_HOME_PATH=$(cd `dirname $0`;pwd)
echo ${TOOL_HOME_PATH}
DATA_TABLE_PATH=$(cd `dirname ${TOOL_HOME_PATH}`;pwd)
DATA_TABLE_PATH=$(cd `dirname ${DATA_TABLE_PATH}`;pwd)
PROJECT_WORK_PATH=$(cd `dirname ${DATA_TABLE_PATH}`;pwd)

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

if [ ! -d ${PROJECT_WORK_PATH}/Genarate/ ];then
	# echo "clean template dir"
	# rm -rf -v ${TempFBSFolder}/*
	# rm -rf -v ${TempBinTableFolder}/*
	# rm -rf -v ${TempIdsTableFolder}/*
	# rm -rf -v ${TempJsonTableFolder}/*
	# rm -rf -v ${TempCSharpFolder}/*
	# rm -rf -v ${TempLuaFolder}/*
	
	tool/linux/MakeTable -f ./tool/linux/flatc ${SrcTableFolder}/ ./gen
	
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

	cp -f -v ./gen/data/ids/*.bytes ${DestTableIdsFolder}/
	cp -f -v ./gen/data/binary/*.bytes ${DestTableFolder}/
	cp -f -v ./gen/code/csharp/*.cs ${DestScriptFolder}/
	cp -f -v ./gen/code/csharp/flatbuffer/*.cs ${DestFlatbufferFolder}/
	cp -f -v ./gen/code/csharp/genarate/*.cs ${DestGenCodeFolder}/

	for file in ${TempExtendFolder}/*.cs; do
	    filename=$(basename "$file")
	    if [ ! -f ${DestExtendCodeFolder}/$filename ]; then
	        cp -f -v "$file" ${DestExtendCodeFolder}/
	    fi
	done

	rm -f -v ${DestTableIdsFolder}/atlas_ids.bytes
	rm -f -v ${DestTableFolder}/atlas.bytes
	rm -f -v ${DestFlatbufferFolder}/DTatlas.cs
	rm -f -v ${DestGenCodeFolder}/AtlasTable.cs
	
	rm -f -v ${DestTableIdsFolder}/sprites_ids.bytes
	rm -f -v ${DestTableFolder}/sprites.bytes
	rm -f -v ${DestFlatbufferFolder}/DTsprites.cs
	rm -f -v ${DestGenCodeFolder}/SpritesTable.cs
else
  ./tool/linux/MakeTable -sa ./tool/linux/flatc ${PROJECT_WORK_PATH}/Genarate/XML/ ${PROJECT_WORK_PATH}/Genarate/.gen
fi

echo "table handle complete"