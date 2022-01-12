using System;
using Cysharp.Threading.Tasks;
using UniRx.Async;
using UniRx.Async.Triggers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace PPD
{
    [InlineEditor]
    public class PPSoButtonTint : ScriptableObject
    {
        [HideLabel, HorizontalGroup("First", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string First { get => "First"; set { } }

        [LabelWidth(60), HorizontalGroup("First", .44f), LabelText("時間㍉秒"), ShowInInspector, PropertyOrder(-1)]
        public int First_duration => 0;

        [LabelWidth(60), HorizontalGroup("First", .44f), LabelText("　カラー")]
        public Color First_color = Color.white;
        // [LabelWidth(60), HorizontalGroup("First", .44f), LabelText("時間㍉秒"), ShowInInspector, PropertyOrder(-1)]
        // public int First_duration => 0;

        // [LabelWidth(60), HorizontalGroup("First", .44f), LabelText("　カラー")]
        // public Color First_color = Color.white;

        [HideLabel, HorizontalGroup("Idle", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Idle { get => "Idle"; set { } }

        [LabelWidth(60), HorizontalGroup("Idle", .44f), LabelText("時間㍉秒")]
        public int Idle_duration = 100;

        [LabelWidth(60), HorizontalGroup("Idle", .44f), LabelText("　カラー")]
        public Color Idle_color = Color.white;

        [HideLabel, HorizontalGroup("Hover", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Hover { get => "Hover"; set { } }

        [LabelWidth(60), HorizontalGroup("Hover", .44f), LabelText("時間㍉秒")]
        public int Hover_duration = 100;

        [LabelWidth(60), HorizontalGroup("Hover", .44f), LabelText("　カラー")]
        public Color Hover_color = Color.white;

        [HideLabel, HorizontalGroup("Down", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Down { get => "Down"; set { } }

        [LabelWidth(60), HorizontalGroup("Down", .44f), LabelText("時間㍉秒")]
        public int Down_duration = 100;

        [LabelWidth(60), HorizontalGroup("Down", .44f), LabelText("　カラー")]
        public Color Down_color = Color.white;

        [HideLabel, HorizontalGroup("Cancel", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Cancel { get => "Cancel"; set { } }

        [LabelWidth(60), HorizontalGroup("Cancel", .44f), LabelText("時間㍉秒")]
        public int Cancel_duration = 100;

        [LabelWidth(60), HorizontalGroup("Cancel", .44f), LabelText("　カラー")]
        public Color Cancel_color = Color.white;

        [HideLabel, HorizontalGroup("Click", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Click { get => "Click"; set { } }

        [LabelWidth(60), HorizontalGroup("Click", .44f), LabelText("時間㍉秒")]
        public int Click_duration = 100;

        [LabelWidth(60), HorizontalGroup("Click", .44f), LabelText("　カラー")]
        public Color Click_color = Color.white;

        [HideLabel, HorizontalGroup("Disable", .12f), ShowInInspector, PropertyOrder(-1), DisplayAsString]
        public string Disable { get => "Disable"; set { } }

        [LabelWidth(60), HorizontalGroup("Disable", .44f), LabelText("時間㍉秒")]
        public int Disable_duration = 100;

        [LabelWidth(60), HorizontalGroup("Disable", .44f), LabelText("　カラー")]
        public Color Disable_color = Color.white;

        internal Color GetColor(ButtonAnimationEvent name)
        {
            switch (name)
            {
                case ButtonAnimationEvent.First:
                    return First_color;
                case ButtonAnimationEvent.Idle:
                    return Idle_color;
                case ButtonAnimationEvent.Hover:
                    return Hover_color;
                case ButtonAnimationEvent.Down:
                    return Down_color;
                case ButtonAnimationEvent.Cancel:
                    return Cancel_color;
                case ButtonAnimationEvent.Click:
                    return Click_color;
                case ButtonAnimationEvent.Disable:
                    return Disable_color;
            }

            return Color.clear;
        }

        internal float GetDuration(ButtonAnimationEvent name)
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