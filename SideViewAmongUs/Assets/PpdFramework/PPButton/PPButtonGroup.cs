using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx.Async;
using UniRx.Async.Triggers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PPD
{
    public class PPButtonGroup : MonoBehaviour
    {
        [LabelText("１つ目のEnterアニメの遅延"), SuffixLabel("㍉秒")] public int firstDelay;
        [LabelText("各Enterアニメの遅延"), SuffixLabel("㍉秒")] public int eachDelayEnter;
        internal List<PPButton> buttons;
        private void Awake()
        {
            GetComponentsInChildren<PPButton>(true, buttons = new List<PPButton>());
            foreach (var b in buttons)
            {
                b.SetRequireDelay(true);
                var o = b.gameObject;
                if (o.activeSelf)
                {
                    o.SetActive(false);
                }
            }
            DelayEnter();
        }

        async void DelayEnter()
        {
            await UniTask.Delay(firstDelay);
            foreach (var b in buttons)
            {
                b.SetRequireDelay(true);
                b.gameObject.SetActive(true);
                b.StartEnterAnim();
                b.SetRequireDelay(false);
                await UniTask.Delay(eachDelayEnter);
            }
        }

        // public void ExitAll()
        // {
        //     foreach (var b in buttons)
        //     {
        //         b.StartExit();
        //     }
        // }

        // async public void ExitAll(int delay)
        // {
        //     foreach (var b in buttons)
        //     {
        //         b.StartExit();
        //         await UniTask.Delay(delay);
        //     }
        // }

        [Button(ButtonSizes.Gigantic), InfoBox("これを呼んでおくとちょっとだけ動作が早くなります")]
        void SetDisableChildren()
        {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}