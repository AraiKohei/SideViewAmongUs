using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PPD
{
    public class SceneLoaderSO : ScriptableObject
    {
#if UNITY_EDITOR
        [OnInspectorGUI("DrawPreview", append: false)]
        [OnValueChanged("CheckNames")]
#endif
        public string SceneName;

        public void LoadScene()
        {
            SceneManager.LoadScene(SceneName);
        }

        

#if UNITY_EDITOR
        enum EnTestResult { 未テスト, 存在します, ビルドに存在しません, }
        EnTestResult Result;

        [Button(ButtonSizes.Gigantic)]
        void CheckNames()
        {
            var BuildScenesList = new List<string>();
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                int lastSlash = scenePath.LastIndexOf("/");
                BuildScenesList.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
            }

            Result = BuildScenesList.Contains(SceneName) ? EnTestResult.存在します : EnTestResult.ビルドに存在しません;
        }

        void DrawPreview()
        {
            GUILayout.BeginHorizontal(GUI.skin.box);
            Texture2D t;
            switch (Result)
            {
                case EnTestResult.未テスト:
                    t = Sirenix.Utilities.Editor.EditorIcons.TestNormal;
                    break;
                case EnTestResult.存在します:
                    t = Sirenix.Utilities.Editor.EditorIcons.TestPassed;
                    break;
                case EnTestResult.ビルドに存在しません:
                    t = Sirenix.Utilities.Editor.EditorIcons.TestFailed;
                    break;
                default:
                    return;
            }
            GUILayout.Label(t, GUILayout.Width(24));
            GUILayout.Label(Result.ToString());
            GUILayout.EndHorizontal();
        }
#endif
    }
}
