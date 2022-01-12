using Sirenix.OdinInspector;
using UnityEngine;

namespace PPD
{
    public class PPSoButtonScale : ScriptableObject
    {
        [HideLabel, HorizontalGroup("First", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string First { get => "First"; set { } }

        [LabelWidth(60), HorizontalGroup("First", .44f), LabelText("時間㍉秒"), ShowInInspector, PropertyOrder(-1)]
        public int First_duration => 0;

        [LabelWidth(60), HorizontalGroup("First", .44f), LabelText("　スケール")]
        public float First_scale = 1;


        [HideLabel, HorizontalGroup("Idle", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Idle { get => "Idle"; set { } }

        [LabelWidth(60), HorizontalGroup("Idle", .44f), LabelText("時間㍉秒")]
        public int Idle_duration = 100;

        [LabelWidth(60), HorizontalGroup("Idle", .44f), LabelText("　スケール")]
        public float Idle_scale = 1;

        [HideLabel, HorizontalGroup("Hover", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Hover { get => "Hover"; set { } }

        [LabelWidth(60), HorizontalGroup("Hover", .44f), LabelText("時間㍉秒")]
        public int Hover_duration = 100;

        [LabelWidth(60), HorizontalGroup("Hover", .44f), LabelText("　スケール")]
        public float Hover_scale = 1;

        [HideLabel, HorizontalGroup("Down", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Down { get => "Down"; set { } }

        [LabelWidth(60), HorizontalGroup("Down", .44f), LabelText("時間㍉秒")]
        public int Down_duration = 100;

        [LabelWidth(60), HorizontalGroup("Down", .44f), LabelText("　スケール")]
        public float Down_scale = 1;

        [HideLabel, HorizontalGroup("Cancel", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Cancel { get => "Cancel"; set { } }

        [LabelWidth(60), HorizontalGroup("Cancel", .44f), LabelText("時間㍉秒")]
        public int Cancel_duration = 100;

        [LabelWidth(60), HorizontalGroup("Cancel", .44f), LabelText("　スケール")]
        public float Cancel_scale = 1;

        [HideLabel, HorizontalGroup("Click", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Click { get => "Click"; set { } }

        [LabelWidth(60), HorizontalGroup("Click", .44f), LabelText("時間㍉秒")]
        public int Click_duration = 100;

        [LabelWidth(60), HorizontalGroup("Click", .44f), LabelText("　スケール")]
        public float Click_scale = 1;

        [HideLabel, HorizontalGroup("Disable", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Disable { get => "Disable"; set { } }

        [LabelWidth(60), HorizontalGroup("Disable", .44f), LabelText("時間㍉秒")]
        public int Disable_duration = 100;

        [LabelWidth(60), HorizontalGroup("Disable", .44f), LabelText("　スケール")]
        public float Disable_scale = 1;

        internal float GetScale(ButtonAnimationEvent name)
        {
            switch (name)
            {
                case ButtonAnimationEvent.First:
                    return First_scale;
                case ButtonAnimationEvent.Idle:
                    return Idle_scale;
                case ButtonAnimationEvent.Hover:
                    return Hover_scale;
                case ButtonAnimationEvent.Down:
                    return Down_scale;
                case ButtonAnimationEvent.Cancel:
                    return Cancel_scale;
                case ButtonAnimationEvent.Click:
                    return Click_scale;
                case ButtonAnimationEvent.Disable:
                    return Disable_scale;
            }

            return 1;
        }

        internal int GetDuration(ButtonAnimationEvent name)
        {
            switch (name)
            {
                case ButtonAnimationEvent.First:
                    return First_duration;
                case ButtonAnimationEvent.Idle:
                    return Idle_duration;
                case ButtonAnimationEvent.Hover:
                    return Hover_duration;
                case ButtonAnimationEvent.Down:
                    return Down_duration;
                case ButtonAnimationEvent.Cancel:
                    return Cancel_duration;
                case ButtonAnimationEvent.Click:
                    return Click_duration;
                case ButtonAnimationEvent.Disable:
                    return Disable_duration;
            }

            return 100;
        }
    }
}
