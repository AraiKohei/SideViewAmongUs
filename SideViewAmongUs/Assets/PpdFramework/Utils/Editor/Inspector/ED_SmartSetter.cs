
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace PPD
{
    [DrawerPriority(0.002, 0, 0)]
    public class ED_SmartSetter<T> : OdinValueDrawer<T>, IDefinesGenericMenuItems
        where T : UnityEngine.Component
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            this.CallNextDrawer(label);
        }

        public void PopulateGenericMenu(InspectorProperty property, GenericMenu genericMenu)
        {
            var parent = (Component)property.Parent.ValueEntry.WeakSmartValue;
            var c = (Component)property.ValueEntry.WeakSmartValue;

            if (parent == null) return;

            if (c == null)
            {
                var finds = parent.GetComponentsInChildren(property.ValueEntry.TypeOfValue);
                if (finds.Length == 1)
                {
                    genericMenu.AddItem(new GUIContent("○Smart Set"), false, (x) =>
                    {
                        Undo.RecordObject(parent, "○Smart Set");
                        property.ValueEntry.WeakSmartValue = finds[0];
                    }, null);
                }
                else if (finds.Length > 1)
                {
                    var find0_Is_Itself = finds[0].gameObject == parent.gameObject;

                    for (int i = 0; i < finds.Length; i++)
                    {
                        var index = i;
                        genericMenu.AddItem(new GUIContent($"○Smart Set/Index/{i + 1}"), false, (x) =>
                        {
                            Undo.RecordObject(parent, "○Smart Set/Index");
                            property.ValueEntry.WeakSmartValue = finds[index];
                        }, null);
                    }

                    if (find0_Is_Itself)
                    {
                        genericMenu.AddItem(new GUIContent("○Smart Set/Itself"), false, (x) =>
                        {
                            Undo.RecordObject(parent, "○Smart Set/Itself");
                            property.ValueEntry.WeakSmartValue = finds[0];
                        }, null);
                        genericMenu.AddItem(new GUIContent("○Smart Set/First Child"), false, (x) =>
                        {
                            Undo.RecordObject(parent, "○Smart Set/First Child");
                            property.ValueEntry.WeakSmartValue = finds[1];
                        }, null);
                    }
                    else
                    {
                        genericMenu.AddDisabledItem(new GUIContent("○Smart Set/Itself"));
                        genericMenu.AddItem(new GUIContent("○Smart Set/First Child"), false, (x) =>
                        {
                            Undo.RecordObject(parent, "○Smart Set/First Child");
                            property.ValueEntry.WeakSmartValue = finds[0];
                        }, null);
                    }

                    genericMenu.AddItem(new GUIContent("○Smart Set/Name Match"), false, (x) =>
                    {
                        var match = property.Name.ToLower();
                        var f = finds[0];
                        foreach (var find in finds)
                        {
                            if (find.name.Trim().ToLower() == match)
                            {
                                f = find;
                            }
                        }
                        Undo.RecordObject(parent, "○Smart Set/Name Match");
                        property.ValueEntry.WeakSmartValue = f;
                    }, null);
                }
                else
                {
                    genericMenu.AddDisabledItem(new GUIContent("○Smart Set"));
                }
            }
            else
            {
                genericMenu.AddDisabledItem(new GUIContent("○Smart Set"));
            }

            // SetSelf
            if (c == null && property.ValueEntry.TypeOfValue == typeof(Transform))
            {
                genericMenu.AddDisabledItem(new GUIContent("○Add Component (Here)"));
                AddComponentInNewChild(property, genericMenu, parent, c);
            }
            else if (c == null)
            {
                genericMenu.AddItem(new GUIContent("○Add Component (Here)"), false, (x) =>
                {
                    property.ValueEntry.WeakSmartValue = Undo.AddComponent(parent.gameObject, property.ValueEntry.TypeOfValue);
                }, null);
                AddComponentInNewChild(property, genericMenu, parent, c);
            }
            else
            {
                genericMenu.AddDisabledItem(new GUIContent("○Add Component (Here)"));
                genericMenu.AddDisabledItem(new GUIContent("○Add Component (New Child)"));
            }
        }

        private static void AddComponentInNewChild(InspectorProperty property, GenericMenu genericMenu, Component parent, Component c)
        {
            genericMenu.AddItem(new GUIContent("○Add Component (New Child)"), false, (x) =>
            {
                var o = new GameObject();
                o.transform.SetParent(parent.transform, false);
                if (property.ValueEntry.TypeOfValue == typeof(Transform))
                    c = o.transform;
                else
                    c = Undo.AddComponent(parent.gameObject, property.ValueEntry.TypeOfValue);

                property.ValueEntry.WeakSmartValue = c;
                o.name = property.Name;

                Undo.RegisterCreatedObjectUndo(o, "○Add Component (New Child)");
            }, null);
        }
    }
}
