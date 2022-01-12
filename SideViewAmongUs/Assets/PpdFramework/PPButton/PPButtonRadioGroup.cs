using Sirenix.OdinInspector;
using UnityEngine;

namespace PPD
{
    /// <summary>
    /// defaultSelectIndexの変更はAwakeで呼ぶこと
    /// </summary>
    [RequireComponent(typeof(PPButtonGroup))]
    public class PPButtonRadioGroup : MonoBehaviour
    {
        PPButtonGroup provider;
        /// <summary>
        /// defaultSelectIndexの変更はAwakeで呼ぶこと
        /// </summary>
        [SuffixLabel("-1で無効")] public int defaultSelectIndex = 0;
        PPButtonRadio selectingButton;
        private void Start()
        {
            provider = GetComponent<PPButtonGroup>();

            if (defaultSelectIndex >= 0)
            {
                selectingButton = (PPButtonRadio)provider.buttons[defaultSelectIndex].extraFunction;
                selectingButton.SetSelect();
            }

            foreach (var button in provider.buttons)
            {
                var radioButton = button.extraFunction as PPButtonRadio;
                radioButton.Init(this, radioButton == selectingButton);
            }
        }

        internal void OnClick(PPButtonRadio buttonToggle)
        {
            if (selectingButton)
            {
                selectingButton.SetUnselect();
            }
            selectingButton = buttonToggle;
            selectingButton.SetSelect();
        }
    }
}