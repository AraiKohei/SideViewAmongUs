using System;
using Sirenix.OdinInspector;
using UnityEngine;
using PPD.DataContents;

namespace PPD
{
    public enum GameMode { Capture, Build, }
    public class Data : _Data_ForReadability
    {
        public static Debugs Debugs => Ins._Debugs;
        public Debugs _Debugs;
        public static LevelDesigns LevelDesigns => Ins._LevelDesigns;
        public LevelDesigns _LevelDesigns;
        public static Prefabs Prefabs => Ins._Prefabs;
        public Prefabs _Prefabs;
    }
}

namespace PPD.DataContents
{
    [TitleGroup("Debugs"), Serializable]
    public class Debugs : Contents
    {
        [BoxGroup("デバッグキー"), LabelText("ステージリトライ"), ReadOnly] public KeyCode debugKey_retry = KeyCode.R;
        [BoxGroup("デバッグキー"), LabelText("次のステージへ"), ReadOnly] public KeyCode debugKey_next = KeyCode.N;
        [BoxGroup("デバッグキー"), LabelText("ステージクリア"), ReadOnly] public KeyCode debugKey_clear = KeyCode.C;
        [BoxGroup("デバッグキー"), LabelText("ステージ失敗"), ReadOnly] public KeyCode debugKey_kill = KeyCode.K;
    }

    [TitleGroup("LevelDesigns"), Serializable]
    public class LevelDesigns : Contents
    {
    }

    [TitleGroup("Prefabs"), Serializable]
    public class Prefabs : Contents
    {
    }
}
