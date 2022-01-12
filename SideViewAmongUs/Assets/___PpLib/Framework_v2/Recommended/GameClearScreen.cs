using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PPD
{
    public class GameClearScreen : SingletonMonoBehaviour<GameClearScreen>
    {
        public TextMeshProUGUI newRecord;
        public TextMeshProUGUI score;
        public GameObject screen;


        [ShowInInspector, DisplayAsString]
        internal int currentLevel;
        bool isTestScene;

        protected override void UnityAwake()
        {
        }

        public void Show()
        {
            Show(false, "");
        }

        public void Show(bool newRecord, string scoreText)
        {
            if (FingerUI.Inst) FingerUI.Inst.FadeOut();
            this.newRecord.SetActiveSelf(newRecord);
            screen.SetActive(true);
            this.score.text = scoreText;
        }
    }
}