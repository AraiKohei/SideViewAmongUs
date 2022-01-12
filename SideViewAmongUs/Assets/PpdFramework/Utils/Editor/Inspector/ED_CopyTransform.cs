using UnityEngine;
using UnityEditor;

namespace PPD
{
    public class ED_CopyTransform
    {
        [MenuItem("CONTEXT/Transform/Copy Component", false, -1)]
        private static void CopyComponent(MenuCommand menuCommand)
        {
            var c = (Component)menuCommand.context;
            UnityEditorInternal.ComponentUtility.CopyComponent(c);
        }

        [MenuItem("CONTEXT/Transform/Paste Component", false, -1)]
        private static void PasteComponent(MenuCommand menuCommand)
        {
            var c = (Component)menuCommand.context;
            UnityEditorInternal.ComponentUtility.PasteComponentValues(c);
        }
    }
}
