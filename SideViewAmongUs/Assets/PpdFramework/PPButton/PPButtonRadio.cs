using Sirenix.OdinInspector;
using UnityEngine;

namespace PPD
{
    class _PPButtonRadio : PPButton_ExtraFunction<PPButtonRadio> { }
    [RequireComponent(typeof(PPButton))]
    [TypeInfoBox("１つONにすると他のはOFFになるボタン郡です。\n「キャラ選択」などで使います。")]
    [InfoBox("PPButtonRadioGroupを親に用意してください。", InfoMessageType.Error, "HasNoParent")]
    public class PPButtonRadio : PPButton_ExtraFunction
    {
        [Title("セレクト中ならvアクティブ", "そうでないなら非アクティブ")]
        public GameObject[] activesOnSelect;

        [Title("セレクト中なら非アクティブ", "そうでないならvアクティブ")]
        public GameObject[] activesOnUnselect;

        PPButtonRadioGroup group;
        bool HasNoParent() => !GetComponentInParent<PPButtonRadioGroup>();

        public void Init(PPButtonRadioGroup group, bool select)
        {
            this.group = group;
            OnStateChange(select);
        }

        public void SetSelect()
        {
            OnStateChange(true);
        }

        public void SetUnselect()
        {
            OnStateChange(false);
        }

        private void OnStateChange(bool select)
        {
            foreach (var e in activesOnSelect)
                if (e.activeSelf != select)
                    e.SetActive(select);

            foreach (var e in activesOnUnselect)
                if (e.activeSelf != !select)
                    e.SetActive(!select);
        }

        public override void OnClick()
        {
            group.OnClick(this);
        }
    }
}