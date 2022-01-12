using System;
using Cysharp.Threading.Tasks;
using UniRx.Async;
using UniRx.Async.Triggers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PPD
{
    [Serializable]
    public class PPButtonSimpleScale : MonoBehaviour, IPPButtonEventHandler
    {
        public PPButton Provider { get; set; }
        public PPSoButtonScale so;
        public Transform scaleChangeTransform;

        float startScale;
        float endScale;
        bool transition;
        float duraiton;
        float timeLeft;

        public void OnStartEnterAnim(ButtonAnimationEvent state)
        {
            OnEventSend(ButtonAnimationEvent.First);
            OnEventSend(state);
        }

        public void OnEventSend(ButtonAnimationEvent ev)
        {
            startScale = scaleChangeTransform.localScale.x;
            endScale = so.GetScale(ev);
            duraiton = so.GetDuration(ev) * 0.001f;
            timeLeft = duraiton;

            if (!transition)
            {
                if (duraiton == 0)
                {
                    scaleChangeTransform.localScale = Vector3.one * endScale;
                }
                else
                {
                    transition = true;
                    Transition().Forget();
                }
            }
        }

        async UniTaskVoid Transition()
        {
            while (true)
            {
                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken: Provider.GetCancellationTokenOnDestroy());
                timeLeft -= Time.deltaTime;

                if (timeLeft <= 0)
                {
                    timeLeft = 0;
                }

                scaleChangeTransform.localScale = Vector3.one * Mathf.Lerp(startScale, endScale, 1 - (timeLeft / duraiton));

                if (timeLeft == 0)
                {
                    break;
                }
            }
            transition = false;
        }
    }
}
