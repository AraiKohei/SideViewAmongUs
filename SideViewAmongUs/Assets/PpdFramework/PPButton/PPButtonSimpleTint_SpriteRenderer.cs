using Cysharp.Threading.Tasks;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace PPD
{
    public class PPButtonSimpleTint_SpriteRenderer : MonoBehaviour, IPPButtonEventHandler
    {
        public PPButton Provider { get; set; }
        public PPSoButtonTint so;
        public Graphic[] graphics;
        public SpriteRenderer[] spriteRenderers;
        Color[] startColors;
        Color endColor;
        bool transition;
        float duraiton;
        float timeLeft;

        public void OnStartEnterAnim(ButtonAnimationEvent state)
        {
            startColors = new Color[graphics.Length + spriteRenderers.Length];
            OnEventSend(ButtonAnimationEvent.First);
            OnEventSend(state);
        }

        public void OnEventSend(ButtonAnimationEvent ev)
        {
            for (int i = 0; i < graphics.Length; i++)
            {
                startColors[i] = graphics[i].color;
            }
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                startColors[i + graphics.Length] = spriteRenderers[i].color;
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

                    for (int i = 0; i < spriteRenderers.Length; i++)
                    {
                        spriteRenderers[i].color = endColor;
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

                for (int i = 0; i < spriteRenderers.Length; i++)
                {
                    spriteRenderers[i].color = Color.Lerp(startColors[i + graphics.Length], endColor, t);
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