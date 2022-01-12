using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace PPD
{
    public class ED_MoveToTop_Bottom
    {
        [MenuItem("CONTEXT/Component/(移動) Move To Top", false)]
        private static void MoveToTop(MenuCommand menuCommand)
        {
            var c = (Component)menuCommand.context;
            var allComponents = c.GetComponents<Component>();

            Undo.RecordObject(c, "(移動) Move To Top");
            int x = 0;
            for (int i = 0; i < allComponents.Length; i++)
            {
                if (allComponents[i] == c)
                {
                    x = i;
                    break;
                }
            }
            for (int i = 0; i < x - 1; i++)
            {
                UnityEditorInternal.ComponentUtility.MoveComponentUp(c);
            }


            EditorSceneManager.MarkAllScenesDirty();
        }

        [MenuItem("CONTEXT/Component/(移動) Move To Bottom", false)]
        private static void MoveToBottom(MenuCommand menuCommand)
        {
            var c = (Component)menuCommand.context;
            var allComponents = c.GetComponents<Component>();

            Undo.RecordObject(c, "(移動) Move To Bottom");
            int x = 0;
            for (int i = 0; i < allComponents.Length; i++)
            {
                if (allComponents[i] == c)
                {
                    x = i;
                    break;
                }
            }

            for (; x < allComponents.Length; x++)
            {
                UnityEditorInternal.ComponentUtility.MoveComponentDown(c);
            }

            EditorSceneManager.MarkAllScenesDirty();
        }
    }
}
