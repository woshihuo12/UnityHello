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

