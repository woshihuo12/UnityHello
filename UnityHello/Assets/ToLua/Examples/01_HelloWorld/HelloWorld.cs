using UnityEngine;
using LuaInterface;

public class HelloWorld : MonoBehaviour
{
    void Awake()
    {
        LuaState lua = new LuaState();
        string hello =
            @"               
                aa = {}
                 
                print('hello tolua#, 广告招租')                
            ";

        lua.DoString(hello, "hello");

        lua.GetFunction("aa.Awake");

        lua.CheckTop();
        lua.Dispose();
        lua = null;
    }
}
