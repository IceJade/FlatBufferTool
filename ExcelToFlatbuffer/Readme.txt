表格工具说明

一、指令文件
	1.生成表格和代码.bat
		执行此脚本可自动化文件：表格二进制文件、表格json文件、表结构文件、解析二进制的代码文件(C#和Lua)、表格管理框架代码;
		生成完以后会自动拷贝到工程对应的目录下.
	
	2.生成表结构文件.bat
		可自动识别表格每一列的数据类型，生成一份表结构文件，并且保存到.\gen\design目录下;
		当某个表的表结构文件已经存在时，那么只会处理新增和删除的列，已存在的列依然使用原始数据；
		当识别到某一列的数据类型跟之前不一致时，依然会使用之前的数据类型，并且会输出日志到.\gen\log目录下提示数据类型有改变.
		
	3.重置表结构文件.bat
	  将原来.\gen\design目录下表结构文件备份到.\gen\backup\design目录下，然后删除原有的表结构文件，再重新生成一份全新的表结构文件;
	  如果某一列的数据类型跟之前不一致，那么会采用新的数据类型.
	  
二、表格工具环境搭建
  表格工具使用.NET Core 3.1开发，故需要安装.NET Core 3.1运行时环境，.NET Core 3.1为跨平台的库，支持Linux、Windows、macOS;
  
	1.下载地址
	  a.网络下载地址:  https://dotnet.microsoft.com/download/dotnet-core/3.1
	  b.共享文件地址： \\drive.im30.lan\公共\software\Tools\.NetCore3.1
	  c.说明：dotnet-sdk-3.1.404-osx-x64.pkg为Mac版本, dotnet-sdk-3.1.404-win-x64.exe为windows版本
	  
	2.安装说明
	  Windows: https://docs.microsoft.com/zh-cn/dotnet/core/install/windows?tabs=net50
	  CentOS:  https://docs.microsoft.com/zh-cn/dotnet/core/install/linux-centos
	  MacOS:   https://docs.microsoft.com/zh-cn/dotnet/core/install/macos
	  
	3.net core 控制台程序发布并运行在linux centos系统说明
	  https://blog.csdn.net/kuui_chiu/article/details/80653439
  
三、各系统自动生成表格的方法
  1.Windows系统下执行指令的方法
	  双击当前目录下的"生成表格和代码.bat"文件即可;
	
  2.MacOS系统下执行指令的方法
    打开终端, CD到此目录下, 然后在终端输入"./生成表格和代码.sh", 回车即可
    
    注意：如果提示Permission denied, 表示对文件没有权限, 需要开通权限。切换到该目录的上一层目录"tools", 输入指令"sudo chmod -R 777 ./MakeConfig", 回车即可
    
四、发布MacOS下的可执行程序
  在Visual Studio 2019里的工程上点击右键 -> 发布(B) -> 目标运行时 -> osx-x64 -> "发布"按钮