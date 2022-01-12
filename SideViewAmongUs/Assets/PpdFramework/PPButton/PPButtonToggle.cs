using Sirenix.OdinInspector;
using UnityEngine;

namespace PPD
{
    class _PPButtonToggle : PPButton_ExtraFunction<PPButtonToggle> { }
    /// <summary>
    /// defaultStateの変更はAwakeで呼ぶこと
    /// </summary>
    [RequireComponent(typeof(PPButton))]
    [TypeInfoBox("ON・OFF状態のあるボタンです。\n「画面シェイク有効⇔無効」などで使用します。")]
    public class PPButtonToggle : PPButton_ExtraFunction
    {
        [ToggleLeft] public bool defaultState;
        [ToggleLeft] [ReadOnly, ShowInInspector] internal bool currentState;

        [Title("ONならvアクティブ", "そうでないなら非アクティブ")]
        public GameObject[] activesIf_ON_;

        [Title("ONなら非アクティブ", "そうでないならvアクティブ")]
        public GameObject[] activesIf_OFF_;

        private void Start()
        {
            currentState = defaultState;
            OnStateChange();
        }

        public override void OnClick()
        {
            currentState = !currentState;
            OnStateChange();
        }

        private void OnStateChange()
        {
            foreach (var activeOnSelect in activesIf_ON_)
                if (activeOnSelect.activeSelf != currentState)
                    activeOnSelect.SetActive(currentState);

            foreach (var activesOnUnselect in activesIf_OFF_)
                if (activesOnUnselect.activeSelf != !currentState)
                    activesOnUnselect.SetActive(!currentState);
        }
    }
}