using UnityEngine;

namespace PPD
{
    /// <summary>
    /// 各プロジェクトで上書きしてください
    /// </summary>
    public class GameEndObserver : PPD_MonoBehaviour
    {
        private void Awake()
        {
        }

        private void Update()
        {
            if (Application.isEditor)
            {
                ObserveShortcut();
            }
        }

        private static void ObserveShortcut()
        {
            if (Input.GetKeyDown(Data.Debugs.debugKey_retry))
            {
                Debug.Log("Rを押されたので再読込します");
                NextSceneLoadHandler.Inst.BeginRetry(true);
            }
            if (Input.GetKeyDown(Data.Debugs.debugKey_next))
            {
                Debug.Log("Nを押されたので次のステージへ進みます");
                NextSceneLoadHandler.Inst.BeginNextLevel();
            }
            if (Input.GetKeyDown(Data.Debugs.debugKey_clear))
            {
                Debug.Log("Cを押されたのでクリアしたことになります");
                GameClearScreen.Inst.Show();
            }
            if (Input.GetKeyDown(Data.Debugs.debugKey_kill))
            {
                Debug.Log("Kを押されたのでゲームオーバーになります");
                GameOverScreen.Inst.Show();
            }
        }
    }
}