using UnityEngine;
using LuaInterface;
using System;
using System.Collections;

public class HelloWorld : MonoBehaviour
{
    IEnumerator Init2()
    {
        yield return AssetBundleLoad.Init();
        Init();
    }

    void Init()
    {

        LuaState lua = new LuaState();
        // lua.AddSearchPath(Application.streamingAssetsPath + "/ToLua/Lua/?");
        // lua.AddSearchPath(Application.streamingAssetsPath + "/ToLua/Lua/?.lua");
        lua.Start();
        string hello =
            @"                
                print('hello tolua#')                                  
            ";

        lua.DoString(hello, "HelloWorld.cs");
        lua.CheckTop();
        lua.Dispose();
        lua = null;
    }

    void Awake()
    {
        StartCoroutine(Init2());
        // Init();
        // WeChatWASM.WX.OpenProfileStats();


    }
}
