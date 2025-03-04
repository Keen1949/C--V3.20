﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("AutoFrame")]
[assembly: AssemblyDescription("Secote Automation")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Secote")]
[assembly: AssemblyProduct("AutoFrame")]
[assembly: AssemblyCopyright("Copyright © Secote 2017 - 2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//将 ComVisible 设置为 false 将使此程序集中的类型
//对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("ff80071c-b31b-4170-ac7a-df2c4a46e82c")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号

//
//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”: :
// [assembly: AssemblyVersion("1.0.*")]4
[assembly: AssemblyVersion("3.17.*")]
//[assembly: AssemblyFileVersion("1.0.0.1")]
//V3.17 Binggoo 1.加入ExcelNPOI类用来操作Excel
//              2.数据管理界面中的表格加入复制粘贴功能，方便从Excel直接复制文件
//              3.把DMC3400类改为DMC3000类，因为DMC3000可以兼容DMC3400、DMC3800、DMC3B00等，更方便理解。
//              4.HelpTool中加入扩展类，用于设置DataGridView和ListView双缓存设置。
//V3.16 Binggoo 1.StationMgr中加入站位弹窗数量改变事件，可以通过计数判断downtime时间
//              2.服务器IP地址变更，更新注册程序。 
//V3.15 Binggoo 1.加入凌臣PCIeM60总线板卡。
//              2.修改CommonTool中LanguageID获取方式，由每次从文件中获取改为在构造函数中获取一次，解决debug模式下程序卡顿的问题。
//              3.当站位禁用时，结束后不调用StationDeInit.
//V3.14 Binggoo 1.程序标题栏中加入显示软件注册剩余天数。
//              2.修改注册软件，保存注册码，在注册文件丢失或损坏后可找回重新注册。
//              3.修改保存注册文件方式，先写到缓存文件，再复制到注册文件，防止写的过程设备出现意外，导致注册文件损坏。
//V3.13 Binggoo 1.当站位不需要界面时，可以传入null，这样手动界面就不会显示界面。
//              2.AddStation加入是否单独显示log参数，当不需要单独显示时，显示在分组的第一个界面上。
//V3.12 Binggoo 1.修改Log4Net配置文件，限制log文件大小.
//              2.重载StationEx中的AxisGoTo方法，可以设置速度百分比和根据PointInfo传入目标点。
//V3.11 Binggoo 1.修改语言切换，可自行配置多种语言包，支持多种语言。          
//V3.10 Binggoo 1.解决三菱PLC类构造函数不匹配的问题。
//              2.解决增加到8轴后，单轴移动/全轴移动/更新点位数组越界的问题。
//              3.单轴移动和全轴移动时加入弹窗提示，防止误操作。
//V3.9 Binggoo 1.在StationBase中记录最近log的队列改为线程安全的ConcurrentQueue,并在操作时加入lock，防止在遍历队列时其他线程操作队列导致报错。
//             2.修改STLib.dll中的监控过期文件功能，判断文件夹的创建时间，防止空文件还没来得急写文件就被删掉。
//             3.解决暂停恢复后，可能出现轴无法恢复的问题。
//V3.8 Binggoo 1.系统参数设置中加入权限等级设置，只有登录用户权限等于或大于设定权限等级才允许修改参数。
//             2.加入系统参数改变事件，把修改前参数和修改后参数输出，可以用于记录日志。
//             3.数据管理类DataMgr中加入数据改变事件。
//             4.用户登录时加入输入工号界面，在AutoFrame.ini中设置工号长度，长度达到后自动退出输入界面。
//             5.ProductMgr中加入LogChanged方法用于记录数据变更。
//V3.7 Binggoo 1.在SystemMgr中加入AppendParamFromResource方法，从资源文件中加载系统参数，用于解决在家里修改系统参数后需要和现场同步的问题。
//             2.在SystemMgr中重载LoadParamFileToGrid方法，可以加载显示指定某一段参数，用于解决系统参数较多时，分块显示。
//             3.在StationMgr中加入AppendPointFromResource方法，从资源文件中加载点位参数，用于解决在家里修改点位后需要和现场同步的问题。
//             4.在DataMgr中加入AppendDataCfgFromResource方法，从资源文件中加载数据配置，用于解决在家里修改点位后需要和现场同步的问题。
//V3.6 Binggoo 1.IoMgr加入获取安全门状态的方法IsSafeDoorOpen();
//             2.在开始时，判断安全门状态，如果安全门开始，弹窗提示是否继续操作。
//             3.当系统运行速度超过50%时，强制启用安全门检查。
//             4.当安全门打开，并关闭安全门功能时，界面背景黄色提示安全门打开，有安全隐患。
//V3.5 Binggoo 1.加入数据库功能。
//             2.完善汇川总线卡运动控制功能，加入连续插补运动和立即插补运动
//             3.加入软件限位功能。
//V3.4 Binggoo 1.单个站位支持轴数扩展到8个，增加A/B/C/D四个轴
//V3.3 Binggoo 1.全部实现中英文切换
//V3.2 Binggoo 1.加入生产数据序列化


