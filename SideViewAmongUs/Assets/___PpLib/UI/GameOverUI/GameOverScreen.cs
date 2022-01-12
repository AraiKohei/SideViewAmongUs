using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PPD
{
    public class GameOverScreen : SingletonMonoBehaviour<GameOverScreen>
    {
        protected override void UnityAwake() { }
        public GameObject view;
        public void Show()
        {
            view.SetActive(true);
            if (FingerUI.Inst) FingerUI.Inst.FadeOut();
        }
    }
}