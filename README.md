# SpiderX.Template

[![.NET Core](https://img.shields.io/badge/.NET%20Core-%203.0-brightgreen)][DotNetCoreUrl]
![License](https://img.shields.io/badge/License-MIT-green)

[DotNetCoreUrl]: https://dotnet.microsoft.com/download
[SpiderXUrl]: https://github.com/LeaFrock/SpiderX

A repo storing templates of [SpiderX][SpiderXUrl].
> 本仓库用来存放[SpiderX项目][SpiderXUrl]的模板。

## Disclaimer |免责声明

For everyone, this repo must be used legally under local law. Users have total responsibility for ensuring their own compliance with legal requirements, while authors and contributors won't be held responsible for actions of illegal users.
>对所有人来说，该项目必须在当地法律允许的范围内使用。使用者对确保自己遵守法律要求负有完全责任，而作者和贡献者对违法使用者的行为概不负责。

All of the codes in this project are just for instructions, learning and communication. If you change the source codes, please obey the open-source license.
>本项目中的所有代码仅用于说明、学习和交流。如果你修改了源代码，请遵守开源协议。

## Instructions |使用说明

### Download |下载

Download the source code directly or use a git commandline, 
- `git clone https://github.com/LeaFrock/SpiderX.Template.git`
>直接下载源码或使用git命令行克隆。

### Install |安装

Take "AddModule" (on Win10) for example,
>以Win10系统上安装AddModule模板为例，
1. Open a CMD.exe;
   >打开CMD程序；
2. Use cd commandlines to enter the directory;
   >使用cd命令进入目录；
   - `D:` //*If the download path is not in 'C:'*.
   - `cd <DownloadPath>\AddModule`
3. Execute dotnet commandline,
   >执行dotnet命令;
   - `dotnet new -i .\`
4. A template whose shortname is called "addspidermod" should appear in the message list.
   >一个短名叫“addspidermod”的模板应该出现在消息列表里。

### Use |使用

For example, a "GithubBll" is required to be created.
>例如，需要创建一个“GithubBll”项目。
1. Create a directory called "Github";
   >创建一个叫“Github”的目录；
2. Open the CMD.exe and `cd` into it;
   >打开CMD程序并进入该目录；
3. Execute dotnet commandline,
   >执行dotnet命令；
   - `dotnet new addspidermod -n Github -ns MyNameSpace`
   
   If you use the default namespace `SpiderX.Business`, you can skip the '-ns' option.
   >如果你使用了默认命名空间`SpiderX.Business`，你可以略过'-ns'选项。
   - `dotnet new addspidermod -n Github`
4. A series of directories including "*Schemes/Collectors/ApiProviders*" should be created. The *.cs* files inside of them shows a basic code framework.
   >模板会创建*Schemes/Collectors/ApiProviders*目录。里面的代码文件展示了一个基础的代码框架。

### Uninstall |卸载

The syntax is like below.
>语法如下。
- `dotnet new -u <AbsoluteInstalledDirectoryPath>`

You can execute the following commandline first.
>可以先执行下面的语句。
- `dotnet new -u`

Then you'll see a list of installed templates with their own uninstall commandlines. Copy and use the one you want.
>然后可以看到一系列已安装模板以及它们各自的卸载指令。复制并执行你想用的那条即可。

## End |结尾

The templates can improve programming efficiency a lot. **Try it by yourself and have fun!**
>模板可以极大地提升编程效率。**自己动手试试吧！祝使用愉快！**
