using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.IO;

namespace Oc
{
    public class ED_MenuDevTool : Editor
    {
        private static Object[] selectionObjects;

        /*
        % : CTRL (Windows) または command (OSX)
        # : Shift
        & : Altキー
        LEFT/RIGHT/UP/DOWN : 方向キー
        F1…F2 : Fキー
        HOME, END, PGUP, PGDN : HOME、END, PageUp, PageDown

        Overcraft/ExampleLog #%1 は Shift + Ctrl + 1
        */
        // [MenuItem("Pocketpair/Tools/RefreshMaterial #%SPACE")]
        // private static void RefreshMaterial()
        // {
        //     AssignNullObject();
        //     EditorApplication.delayCall += AssignOriginalSelection;
        // }

        [MenuItem("Pocketpair/Tools/Capture")]
        public static void TakeScreenShot()
        {

            string projName = PlayerSettings.productName; //プロジェクト名
            string width = $"{Screen.width}"; //横幅
            string height = $"{Screen.height}"; //縦幅

            string fileBaseName = projName + "_" + width + "x" + height; //ApplicationName_1242x2208 ←といった具合に生成

            string folderpass = $"{Application.dataPath}/../Capture/";
            for (int i = 1; i < 100; i++)
            {
                string serialNumber = "_" + (i).ToString();
                if (!File.Exists(folderpass + fileBaseName + serialNumber + ".png")) //同名のファイルが存在しない場合
                {
                    ScreenCapture.CaptureScreenshot(string.Format($"{folderpass + fileBaseName + serialNumber + ".png"}"));
                    Debug.Log($"{folderpass + fileBaseName + serialNumber + ".png"}");
                    break;
                }
            }
        }

        [MenuItem("Pocketpair/Tools/OpenCaptureFolder")]
        public static void OpenCaptureFolder()
        {
            string folderpass = $"{Application.dataPath}/../Capture/";
            EditorUtility.RevealInFinder(folderpass);
        }

        private static void AssignNullObject()
        {
            //Debug.Log("OC: AssignNullObject");
            selectionObjects = Selection.objects;
            Selection.objects = new Object[0];
        }

        private static void AssignOriginalSelection()
        {
            Debug.Log("OC: Material Refreshed");
            Selection.objects = selectionObjects;
            EditorApplication.delayCall -= AssignOriginalSelection;
        }

        [MenuItem("Pocketpair/Tools/Trigger Recompile %T")]
        private static void TriggerRecompile()
        {
            GenerateDummyScript();
            AssetDatabase.Refresh();
        }

        [MenuItem("Pocketpair/Tools/Clear Console %&#C")]
        private static void ClearConsole()
        {
            var assembly = Assembly.GetAssembly(typeof(SceneView));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }

        static readonly string SAVE_FILE_POINT = "/___PpApp/zzzTemp/";
        private static void GenerateDummyScript()
        {
            string assetPath = Application.dataPath + SAVE_FILE_POINT + "ForceRecompileDummy.cs";
            var textScript = $@"
                namespace Oc
                {{
                    public class ForceRecompileDummyDayo
                    {{
                        // ここはランダムで毎回変わるよ {Random.Range(0, 10000)}
                    }}
                }}
            ";
            System.IO.File.WriteAllText(assetPath, textScript);
        }
    }
}