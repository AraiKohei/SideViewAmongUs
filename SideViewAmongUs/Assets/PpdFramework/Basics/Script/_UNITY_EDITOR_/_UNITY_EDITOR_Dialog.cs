using System.Diagnostics;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PPD
{
    public static partial class UNITY_EDITOR
    {
        public static class Dialog
        {
            [Conditional("DEVELOPMENT_BUILD"), Conditional("UNITY_EDITOR")]
            public static void Error(string message, string personResponsible = null)
            {
#if UNITY_EDITOR
                if (personResponsible == null)
                    EditorUtility.DisplayDialog("エラー!", $"{message}", "OK");
                else
                    EditorUtility.DisplayDialog("エラー!", $"{message}\n\n{personResponsible}に連絡して下さい", "OK");

                UnityEngine.Debug.LogError(message);
#endif
            }

            [Conditional("DEVELOPMENT_BUILD"), Conditional("UNITY_EDITOR")]
            public static void Display(string message)
            {
#if UNITY_EDITOR
                EditorUtility.DisplayDialog("メッセージ", message, "OK");
#endif
            }


            [Conditional("DEVELOPMENT_BUILD"), Conditional("UNITY_EDITOR")]
            public static void Display(string title, string message, string ok = "OK")
            {
#if UNITY_EDITOR
                UnityEngine.Debug.Log($"{title}\n{message}");
                EditorUtility.DisplayDialog(title, message, ok);
#endif
            }

            public static bool Confirm(string message, string ok = "OK", string cancel = "Cancel")
             => ConfirmWithTitle("確認", message, ok, cancel);

            public static bool ConfirmWithTitle(string title, string message, string ok = "OK", string cancel = "Cancel")
            {
#if UNITY_EDITOR
                return EditorUtility.DisplayDialog(title, message, ok, cancel);
#else
            return true;
#endif
            }
        }
    }
}
