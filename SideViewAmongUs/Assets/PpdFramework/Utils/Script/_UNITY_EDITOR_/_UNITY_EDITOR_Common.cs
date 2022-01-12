using System.Diagnostics;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PPD
{
    public static partial class UNITY_EDITOR
    {
        public static partial class Common
        {
            /// <summary>
            /// Target コンポーネントの直下に移動させます。
            /// </summary>
            [Conditional("DEVELOPMENT_BUILD"), Conditional("UNITY_EDITOR")]
            public static void MoveJustBelow<Target>(Component self, bool record)
            where Target : Component
            {
#if UNITY_EDITOR
                var parentProvider = self.GetComponent<Target>();
                if (parentProvider == null) return;

                var allComponents = self.GetComponents<Component>();
                var parentIndex = Array.IndexOf(allComponents, parentProvider);

                int selfIndex = 0;
                for (int i = 0; i < allComponents.Length; i++)
                {
                    if (allComponents[i] == self)
                    {
                        selfIndex = i;
                        break;
                    }
                }

                if (record)
                {
                    Undo.RecordObject(self.gameObject, "Move Just Below");
                }

                for (int i = 0; i < selfIndex - parentIndex - 1; i++)
                {
                    UnityEditorInternal.ComponentUtility.MoveComponentUp(self);
                }
#endif
            }
        }
    }
}
