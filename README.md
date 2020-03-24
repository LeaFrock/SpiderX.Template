# SpiderX.Template

[SpiderXTemplateSvgUrl]: https://img.shields.io/nuget/v/SpiderX.Template.svg
[SpiderXTemplateNugetUrl]: https://www.nuget.org/packages/SpiderX.Template
[SpiderXTemplatePacksNugetUrl]: https://www.nuget.org/packages/SpiderX.TemplatePacks
[SpiderXTemplatePacksSvgUrl]: https://img.shields.io/nuget/v/SpiderX.TemplatePacks.svg
[DotNetCoreUrl]: https://dotnet.microsoft.com/download
[SpiderXUrl]: https://github.com/LeaFrock/SpiderX

[![.NET Core](https://img.shields.io/badge/.NET%20Core-%203.1-brightgreen)][DotNetCoreUrl]
![License](https://img.shields.io/badge/License-MIT-green)

CLI & Templates of [SpiderX][SpiderXUrl].
> 本仓库用来存放[SpiderX项目][SpiderXUrl]的命令行工具和模板。

## Disclaimer |免责声明

For everyone, this repo must be used legally under local law. Users have total responsibility for ensuring their own compliance with legal requirements, while authors and contributors won't be held responsible for actions of illegal users.
>对所有人来说，该项目必须在当地法律允许的范围内使用。使用者对确保自己遵守法律要求负有完全责任，而作者和贡献者对违法使用者的行为概不负责。

## Packages |Nuget包

|         Name          | Description |                                    NugetPackage                                    |
| :-------------------: | :---------: | :--------------------------------------------------------------------------------: |
|   SpiderX.Template    | Global tool |       [![Global Tool Nuget][SpiderXTemplateSvgUrl]][SpiderXTemplateNugetUrl]       |
| SpiderX.TemplatePacks |  Templates  | [![TemplatePacks Nuget][SpiderXTemplatePacksSvgUrl]][SpiderXTemplatePacksNugetUrl] |

## Instructions |使用说明

*In the meanwhile of use, it's better to **ensure network connection**. Otherwise some commandlines might not work properly.*
>*在使用期间，最好**确保网络连接**。否则部分命令可能不会有效执行。*

### Install |安装

Execute a dotnet-tool commandline to install the global tool.
>执行dotnet-tool命令行安装全局工具。

`dotnet tool install -g SpiderX.Template`

### Use |使用

*The 'spiderx' commandlines are tested by (& recommended for) working with **Package Manager Console** of Visual Studio(16.5+).*
>*‘spiderx’系列指令在Visual Studio(16.5+)的**程序包管理器控制台**上进行了测试（同样也推荐这么使用）。*

* `spiderx new`

  * Params |参数
    |  FullName   | ShortName |                  Description                   |     Type      | Required |   DefaultValue    |
    | :---------: | :-------: | :--------------------------------------------: | :-----------: | :------: | :---------------: |
    |  --project  |    -p     |   Give the name of new project to be created   |    String     |   true   |        --         |
    | --namespace |    -n     |       Give the namespace of new project        |    String     |  false   | SpiderX.Business  |
    |  --version  |    -v     |   Select which version of template to apply    |    String     |  false   |       null        |
    |  --output   |    -o     |          Set the output path of files          | DirectoryInfo |  false   | Current directory |
    |   --force   |    -f     | Update(/Reinstall) and use the latest template |     Bool      |  false   |       false       |

  * Samples |样例

    1. `spiderx new -p Github`

    2. `spiderx new -p Github -n MyNamespace -v 0.1.0 -o C:\\MyDirectory`

### Uninstall |卸载

1. Execute a dotnet-tool commandline to uninstall the global tool.
    >执行dotnet-tool命令行卸载全局工具。

    `dotnet tool uninstall -g SpiderX.Template`

2. Execute a dotnet-new commandline to uninstall related templates.
    >执行dotnet-new命令行卸载相关模板。

    `dotnet new -u SpiderX.TemplatePacks`

## References |参考

* Microsoft Docs: [How to manage .NET Core tools](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools)
  >微软文档：[如何管理 .NET Core 工具](https://docs.microsoft.com/zh-cn/dotnet/core/tools/global-tools)

* Microsoft Docs: [Custom templates for dotnet new](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates)
  >微软文档：[dotnet new 自定义模板](https://docs.microsoft.com/zh-cn/dotnet/core/tools/custom-templates)

## End |结束语

The templates can improve the efficiency of programming a lot. **Try it by yourself and have fun!**
>模板可以极大地提升编程效率。**自己动手试试吧！祝使用愉快！**
