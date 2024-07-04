echo 生成json文件

flatc.exe --raw-binary -t -o .\gen\data\json .\gen\fbs\DTquest.fbs -- .\gen\data\binary\quest.bin

@pause