using System;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace PPD
{
    public enum ButtonAnimationEvent
    {
        First, Idle, Hover, Down, Cancel, Click, /*Exit,*/ Disable
    }

    interface IPPButtonEventHandler
    {
        PPButton Provider { set; }
        void OnStartEnterAnim(ButtonAnimationEvent state);
        void OnEventSend(ButtonAnimationEvent ev);
    }
    public class PPButton : MonoBehaviour,
            IPointerEnterHandler, IPointerExitHandler,
            IPointerDownHandler, IPointerUpHandler,
            IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public enum EnClickKeep
        {
            Lv0_マウスExitで解除, Lv1_再Hoverで解除, Lv2_再Downで解除,
        }
        [LabelText("クリック状態の保持")] public EnClickKeep ClickKeep = EnClickKeep.Lv1_再Hoverで解除;
        bool interactive => this.enabled;
        // [SerializeField, LabelText("クリックしたらExitする"), ToggleLeft] bool exitOnClick;
        ButtonAnimationEvent state = ButtonAnimationEvent.First;
        [ReadOnly, ShowInInspector, HideInEditorMode] internal PPButton_ExtraFunction extraFunction;
        // [DrawWithUnity] 
        public UnityEvent onClick;
        IPPButtonEventHandler[] eventHandler;
        bool requiredDelay;

        //TODO: SimpleAnimは UnityEventTools でいけるかも
        // [ShowInInspector, HideLabel, HorizontalGroup] public string Idle => ButtonAnimationEvent.Idle.ToString();
        // [ShowInInspector, HideLabel, HorizontalGroup] public string Hover => ButtonAnimationEvent.Hover.ToString();
        // [ShowInInspector, HideLabel, HorizontalGroup] public string Down => ButtonAnimationEvent.Down.ToString();
        // [ShowInInspector, HideLabel, HorizontalGroup] public string Cancel => ButtonAnimationEvent.Cancel.ToString();
        // [ShowInInspector, HideLabel, HorizontalGroup] public string Click => ButtonAnimationEvent.Click.ToString();
        // // [ShowInInspector, HideLabel, HorizontalGroup] public string Exit => ButtonAnimationEvent.Exit.ToString();
        // [ShowInInspector, HideLabel, HorizontalGroup] public string Disable => ButtonAnimationEvent.Disable.ToString();

        [ButtonGroup, Button("+Tint")] void AddSimpleTint() => gameObject.AddComponent<PPButtonSimpleTint>();
        [ButtonGroup, Button("+Scale")] void AddSimpleScale() => gameObject.AddComponent<PPButtonSimpleScale>();

        [Button("特殊機能の追加。《↓を開いて選んで→を押す》")]
        void AddExtraFunction(_PPButton_ExtraFunction ExtraFunction) => gameObject.AddComponent(ExtraFunction.Type);

        internal void SetRequireDelay(bool flg)
        {
            requiredDelay = flg;
        }

        private void Awake()
        {
            eventHandler = GetComponents<IPPButtonEventHandler>();
            for (int i = 0; i < eventHandler.Length; i++)
            {
                eventHandler[i].Provider = this;
            }
            if (!interactive)
            {
                OnDisable();
            }
        }

        private void OnEnable()
        {
            if (requiredDelay) return;

            StartEnterAnim();
        }

        private void OnDisable()
        {
            StartEnterAnim();
        }

        public void StartEnterAnim()
        {
            state = interactive ? ButtonAnimationEvent.Idle : ButtonAnimationEvent.Disable;
            for (int i = 0; i < eventHandler.Length; i++)
            {
                eventHandler[i].OnStartEnterAnim(state);
            }
        }

        // public void StartExit()
        // {
        //     state = ButtonAnimationEvent.Exit;
        //     OnStateChange();
        //     AsyncStartExit();
        // }

        // async void AsyncStartExit()
        // {
        //     var exitDuration = 0;
        //     for (int i = 0; i < eventHandler.Length; i++)
        //     {
        //         exitDuration = Mathf.Max(exitDuration, eventHandler[i].GetExitDuration());
        //     }
        //     await UniTask.Delay(exitDuration);
        //     this.gameObject.SetActive(false);
        // }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!interactive) return;

            if (state == ButtonAnimationEvent.Click)
            {
                if (ClickKeep == EnClickKeep.Lv2_再Downで解除)
                {
                    return;
                }
                else
                {
                    state = ButtonAnimationEvent.Hover;
                    OnStateChange();
                }
            }

            if (state == ButtonAnimationEvent.Idle)
            {
                state = ButtonAnimationEvent.Hover;
                OnStateChange();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!interactive) return;
            state = ButtonAnimationEvent.Down;
            OnStateChange();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!interactive) return;
            if (state == ButtonAnimationEvent.Down)
            {
                // if (exitOnClick)
                // {
                //     state = ButtonAnimationEvent.Exit;
                // }
                // else
                {
                    state = ButtonAnimationEvent.Click;
                }
                OnStateChange();

                onClick.Invoke();
                if (extraFunction != null)
                {
                    extraFunction.OnClick();
                }
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!interactive) return;
            state = ButtonAnimationEvent.Cancel;
            OnStateChange();
        }

        public void OnDrag(PointerEventData eventData) { }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (state == ButtonAnimationEvent.Cancel)
            {
                state = ButtonAnimationEvent.Idle;
                OnStateChange();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!interactive) return;
            switch (state)
            {
                case ButtonAnimationEvent.Cancel:
                    return;
                case ButtonAnimationEvent.Click:
                    if (ClickKeep != EnClickKeep.Lv0_マウスExitで解除)
                    {
                        return;
                    }
                    break;
            }
            state = ButtonAnimationEvent.Idle;
            OnStateChange();
        }

        private void OnStateChange()
        {
            for (int i = 0; i < eventHandler.Length; i++)
            {
                eventHandler[i].OnEventSend(state);
            }
        }
    }
}
