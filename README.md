# UnityHello
Unity版hello world,演示了各种tolua相关的hello world级程序，所以取名为hello

基于  unity5.3+
https://github.com/topameng/tolua

https://github.com/tinyantstudio/UIFrameWork

https://github.com/jarjin/LuaFramework_UGUI.git

https://github.com/chuxiang9007/xlsx2lua-language.git

1：基于texturepacker的ugui的使用，为什么用tp，实验它打的图集要比ugui的紧凑（整体都是用texturepacker打的图集拼的界面，framedebug可以看到dc是3（1个是默认就有的，说白了就是2个），topbar右边按钮点击下会变红色背景） 

2:proto-gen-lua 基本使用，topbar左边按钮点出 messagebox, 左边按钮 encode， 右边按钮decode，顺序不要反哦，proto生成文件位于Asset/Editor下，已经继承到菜单    [MenuItem("CustomEditorTool/Protobuf-Gen-Lua", false, 110)]  中，方便使用

3:string_table 本地化。 集成到菜单[MenuItem("CustomEditorTool/StringTableTool", false, 100)] ，方便使用，就是将xlsl表转lua，messagebox的按钮文字就是从 stringtable取得。

4：timer用法。topbar顶部的倒计时就是 timer的小例子，按右边按钮会 停止计时

5：leantween小示例：messagebox弹出动画就是leantween做的，为什么用leantween而没用dotween，是因为dotween不好导入tolua，leantween直接导就能用，所以就不纠结了。

6：ZeroBraneStudio 调试lua程序：LuaManager.cs 下 SimpleLuaClient类 的public void OnLuaFilesLoaded() 方法里，将   //OpenZbsDebugger();注释解掉，将ZeroBraneStudio 下载到 D盘根目录，按照调试步骤就可以调试了。。

关于Lua代码风格想说两句
自己之前也没接触过lua，当然也没写过。
群里大神说ios和android都有不同程度的文件名大小写敏感问题，所以为了想避免打assetbundle过程中可能出现的潜在的坑位，我们需要对代码风格做出一些约束。由于随着程序员工人数的增多，基于lua语言的特点，为了方便大家交流，故做出一些风格上的约束：

1. UI界面prefab 名字以ui_开头，名字全小写
2. TP打出来的atlas图集以res_atlas_开头，名字需与文件夹同名，名字全小写
3. tolua插件相关代码模块及导出的代码风格不做修改
4. unity相关的代码模块保持原有驼峰风格不做修改
5. 自己所写lua文件或者说模块，文件名全小写，采用下划线隔开命名方式
6. 自己所写lua模块中类（姑且这么说）名字全小写，采用下划线隔开命名方式
7. 自己所写lua模块中类所属方法 名字全小写，采用下划线隔开命名方式，如果你认为此方法别人不应调用，请前置 _ 下划线
8. 自己所写lua模块中类所属成员变量 名字全小写，采用下划线隔开命名方式，如果你认为此变量别人不应调用，请前置 _ 下划线
9. 常量table名字全小写，采用下划线隔开命名方式，里面的常量名字  全大写，采用下划线隔开命名方式
10. 枚举table名字全小写，采用下划线隔开命名方式，里面的枚举名字  全大写，采用下划线隔开命名方式

代码风格是为了大家更方便的交流，以及整体的整洁所以做出约定，如果有不足之处欢迎指正，约定指定后也需严格按照约定所要求的书写代码。
