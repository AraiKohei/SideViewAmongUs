using System;
using PPD.DataContents;
using Sirenix.OdinInspector;
using UnityEngine;

/*　
 * ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
 * |　このファイルに変数を追加しないでください
 * |　Data.csに追加してください by ウェレイ
 * ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
 */

namespace PPD
{
    [TypeInfoBox("　このアセットを毎回探すのがめんどうなあなたへ！\n　[ToolBar] > Pocketpair > ショートカットから選択できます（Ctrl + Alt + D）")]
    public abstract class _Data_ForReadability : ScriptableObject
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Pocketpair/ショートカット/Data.soを選択する %&d")]
        private static void SelectDataSO()
        {
            UnityEditor.Selection.activeObject = Data.Ins;
        }
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void InitializeOnLoad()
        {
            Application.targetFrameRate = 30;
            var o = new GameObject("Inited By DataSo");
            CoroutineHandler = o.AddComponent<CoroutineHandler>();
            GameObject.DontDestroyOnLoad(o);
        }

        public static CoroutineHandler CoroutineHandler { get; private set; }

        static Data _Ins;
        public static Data Ins
        {
            get
            {
                if (_Ins == null)
                {
                    _Ins = Resources.Load<Data>("_DataSO");
                }
                return _Ins;
            }
        }

        public static Templates Templates => Ins._Templates;
        [PropertyOrder(255)]
        public Templates _Templates;
    }
}

namespace PPD.DataContents
{
    [HideLabel]
    public abstract class Contents { }

    [TitleGroup("HCGテンプレ")]
    [Serializable]
    public class Templates : Contents
    {
        [LabelText("ゲームモード"), PropertyOrder(-2), EnumToggleButtons]
        public GameMode gameMode;

        [LabelText("重力"), ShowInInspector]
        public float Gravity
        {
            get => Physics.gravity.y;
            set
            {
                Physics.gravity = new Vector3(Physics.gravity.x, value, Physics.gravity.z);
                Physics2D.gravity = new Vector2(Physics2D.gravity.x, value);
            }
        }

        [BoxGroup("シーン読み込み"), LabelText("シェイク秒")] public float nextSceneLoadHandler_shakeSec = 0.5f;
        [BoxGroup("シーン読み込み"), LabelText("フェードアウト秒")] public float nextSceneLoadHandler_fadeoutSec = 0.15f;
        [BoxGroup("シーン読み込み"), LabelText("フェードイン秒")] public float nextSceneLoadHandler_fadeinSec = 0.4f;
        [BoxGroup("シーン読み込み"), LabelText("フェード色、開始時")] public Color nextSceneLoadHandler_defaultColor = new Color(0, 0, 0, 0);
        [BoxGroup("シーン読み込み"), LabelText("フェード色、頂点時")] public Color nextSceneLoadHandler_peakColor = new Color(0, 0, 0, 1);
        [BoxGroup("入力"), InfoBox("画面幅に対して、指をどれくらい動かすべきか"), Range(0, 1)]
        public float fingerRange = 0.4f;
        [BoxGroup("入力"), LabelText("UE上のマウステスト用の感度倍率")] public float sensivityOnEditor = 4;
        [BoxGroup("入力"), LabelText("右中クリックしたときTimescaleを変更する")] public bool activeTimescaleChanger = true;
        [BoxGroup("入力"), LabelText("右クリックしたときのTimescale")] public float timescale_R = 2;
        [BoxGroup("入力"), LabelText("中クリックしたときのTimescale")] public float timescale_C = 3;

        [BoxGroup("キャラクター"), LabelText("歩行速度")] public float characterWalkSpeed;
        [BoxGroup("キャラクター"), LabelText("振り向き感度")] public float characterAdjRotParameter;
    }
}
