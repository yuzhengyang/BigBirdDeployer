using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("Oreo.BigBirdDeployer")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Oreo.BigBirdDeployer")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("09a73ef5-ba8f-4757-a3ea-303d82cebc85")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
// 可以指定所有值，也可以使用以下所示的 "*" 预置版本号和修订号
// 方法是按如下所示使用“*”: :
// [assembly: AssemblyVersion("1.0.*")]
//[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: AssemblyVersion("1.0.0.3")]
//v*.*.*.*（年月日）//+添加 -删减 @优化 #修复

// v 1.0.0.3（2018年5月25日）
// + 设置窗口名称
// + 支持带空格程序路径
// + 扩展项目支持个数


// v 1.0.0.2（2018年5月18日）
// @ 优化输出内容策略（降低卡顿）
// + 显示版本（版本特性及控制）
// + 添加输出序号选项（增加调试体验）
// + 停止输出内容（提供调试条件）
// - 高亮关键字（导致较卡顿的体验，回归流畅）


// v 1.0.0.1（2018年5月17日）
// + 控制台输出（提供调试条件）
// + 高亮输出关键字（提高注意力体验）
