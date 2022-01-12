using System;
using Cysharp.Threading.Tasks;
using UniRx.Async;
using UniRx.Async.Triggers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace PPD
{
    public class PPButtonSimpleTint : MonoBehaviour, IPPButtonEventHandler
    {
        public PPButton Provider { get; set; }
        public PPSoButtonTint so;
        public Graphic[] graphics;
        Color[] startColors;
        Color endColor;
        bool transition;
        float duraiton;
        float timeLeft;

        public void OnStartEnterAnim(ButtonAnimationEvent state)
        {
            startColors = new Color[graphics.Length];
            OnEventSend(ButtonAnimationEvent.First);
            OnEventSend(state);
        }

        public void OnEventSend(ButtonAnimationEvent ev)
        {
            for (int i = 0; i < graphics.Length; i++)
            {
                startColors[i] = graphics[i].color;
            }

            endColor = so.GetColor(ev);
            duraiton = so.GetDuration(ev) * 0.001f;
            timeLeft = duraiton;

            if (!transition)
            {
                if (duraiton == 0)
                {
                    for (int i = 0; i < graphics.Length; i++)
                    {
                        graphics[i].color = endColor;
                    }
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

                var t = 1 - (timeLeft / duraiton);
                for (int i = 0; i < graphics.Length; i++)
                {
                    graphics[i].color = Color.Lerp(startColors[i], endColor, t);
                }

                if (timeLeft == 0)
                {
                    break;
                }
            }
            transition = false;
        }
    }
}