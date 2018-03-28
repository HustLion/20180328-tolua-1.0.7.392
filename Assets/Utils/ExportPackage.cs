using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class ExportPackage {

    [MenuItem("Lua/Export ToLua Unitypackage")]
    static void ExportToLua() {
        Debug.Log("Exporting tolua unitypackage");
        string[] allAssets = AssetDatabase.GetAllAssetPaths();

        string pattern = BuildWildPattern("^Assets/ThirdParty/ToLua/")
            + "|" + BuildWildPattern("^Assets/Lua")
            + "|" + BuildWildPattern("^Assets/Scripts/Generated")
            + "|" + BuildWildPattern("^Assets/Scripts/ToLuaConfig")
            + "|" + BuildWildPattern("^Assets/Plugins");

        Debug.Log("pattern: " + pattern);

        var libAssetPaths = new List<string>();

        foreach (var a in allAssets)
        {
            //Debug.Log(a);
            if (Regex.IsMatch(a, pattern))
            {
                //Debug.Log("Got a match");
                libAssetPaths.Add(a);
            }
        }

        foreach (var item in libAssetPaths)
        {
            Debug.Log("matched: " + item);
        }

        AssetDatabase.ExportPackage(libAssetPaths.ToArray(), "dist/tolua.unitypackage");
    }
    static string BuildWildPattern(string raw)
    {
        return raw + ".*";
    }

    static string BuildCsPattern(string raw) {
        return ".*" + raw + ".*\\.cs";
    }
}
