using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Diagnostics;

public class CustomEditorTool : MonoBehaviour
{
    [MenuItem("CustomEditorTool/StringTableTool")]
    private static void StringTableTool()
    {

        string dirName = Application.dataPath + "/Editor/StringTableTool";
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = dirName + "/StringTableTool.bat";
        //info.Arguments = "";
        info.WindowStyle = ProcessWindowStyle.Hidden;
        info.UseShellExecute = true;
        info.WorkingDirectory = dirName;
        info.ErrorDialog = true;
        UnityEngine.Debug.Log(info.WorkingDirectory);
        Process pro = Process.Start(info);
        pro.WaitForExit();
    }
}
