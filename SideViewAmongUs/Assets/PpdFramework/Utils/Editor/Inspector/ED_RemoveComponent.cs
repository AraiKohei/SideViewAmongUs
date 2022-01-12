using UnityEngine;
using UnityEditor;

namespace PPD
{
    public class ED_RemoveComponent
    {
        [MenuItem("CONTEXT/Component/Remove Component .", false, -3)]
        private static void RemoveComponent(MenuCommand menuCommand)
        {
            Undo.DestroyObjectImmediate(menuCommand.context);
        }
    }
}
