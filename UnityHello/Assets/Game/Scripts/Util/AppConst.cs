using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LuaFramework {
    public class AppConst {
		public static bool LuaByteMode = false;                       //Lua字节码模式-默认关闭 ;
#if UNITY_EDITOR
        public static bool LuaBundleMode = UnityEditor.EditorPrefs.GetBool("ResLoadMode", false) ? false : true;                   //Lua代码AssetBundle模式;
#else
		public static bool LuaBundleMode = true;                    //Lua代码AssetBundle模式;
#endif
        public static bool BundleEncyptMode = false;
       


		public const string AppName = "LuaFramework";               //应用程序名称;
        public const string LuaTempDir = "Temp/";                    //临时目录;
        public const string AppPrefix = AppName + "_";              //应用程序前缀;
        public const string AssetDir = "StreamingAssets";           //素材目录 ;
		public const string OutPutDir = "./OutPut";					//输出路径;
        public const string ProjectLuaRootPath = "Scripts/LuaFramework/Lua/";

        public static string FrameworkRoot {
            get {
                return Application.dataPath + "/Scripts/" + AppName;
            }
        }
    }
}