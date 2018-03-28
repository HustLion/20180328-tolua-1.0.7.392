using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
/// <summary>
/// tolua 启动入口，将此脚本动态绑定到一个不销毁的 GameObject 上，通常跟游戏的 GameManagr 绑在同物体上
/// 来自：《Unity 3D游戏客户端基础框架》tolua 框架接入 
/// https://blog.csdn.net/linshuhe1/article/details/77816480
/// </summary>
public class LuaEngine : LuaClient
{

    protected override LuaFileUtils InitLoader()
    {
        return new LuaResLoader();
    }

    /// <summary>
    /// 可添加或修改搜索 lua 文件的目录
    /// </summary>
    protected override void LoadLuaFiles()
    {
#if UNITY_EDITOR
        // 添加编辑器环境下获取 lua 脚本的路径（Assets/lua）
        luaState.AddSearchPath(Application.dataPath + "/lua");
#endif
        OnLoadFinished();
    }
}