using UnityEditor;
using UnityEngine;

namespace PPD
{
    public static class ED_Renamer
    {
        [MenuItem("CONTEXT/Component/オブジェクト名を変更", false, -3)]
        private static void Rename(MenuCommand menuCommand)
        {
            var c = menuCommand.context as Component;
            Undo.RecordObject(c.gameObject, "名前変更");
            c.name = GetName_UNITY_EDITOR(c);
        }

        public static string GetName_UNITY_EDITOR(Component c)
        {
            var n = c.GetType().ToString();
            return n.Substring(n.LastIndexOf(".") + 1);
        }
    }
}
