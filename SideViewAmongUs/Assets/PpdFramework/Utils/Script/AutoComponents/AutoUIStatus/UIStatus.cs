using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace PPD
{
    [Serializable]
    public class UIStatus
    {
        [Serializable]
        public struct AnimationChange
        {
            public string state;
            // もしSimpleAnimationを利用していないなら、#if true を #if falseに変えてください
#if true
            public SimpleAnimation animator;
            internal void Play()
            {
                animator.Play(state);
            }
#endif

            // #if false だとこちらのPlayが呼ばれます。
            internal void Play(object dummy = null)
            {
#if UNITY_EDITOR
                UNITY_EDITOR.Dialog.Error("SimpleAnimationをインポートして、UIStatus.csを編集してください。");
#endif
            }
        }

        public string StatusName;

        [FoldoutGroup("OnActivate")] public GameObject[] showOnActivate;
        [FoldoutGroup("OnActivate")] public GameObject[] hideOnActivate;
        [FoldoutGroup("OnActivate")] public ColorChange[] colorChangeOnActivate;
        [FoldoutGroup("OnActivate")] public SpriteChange[] spriteChangeOnActivate;
        [FoldoutGroup("OnActivate")] public AnimationChange[] animationChangeOnActivate;

        [FoldoutGroup("OnDeactivate")] public GameObject[] showOnDeactivate;
        [FoldoutGroup("OnDeactivate")] public GameObject[] hideOnDeactivate;
        [FoldoutGroup("OnDeactivate")] public ColorChange[] colorChangeOnDeactivate;
        [FoldoutGroup("OnDeactivate")] public SpriteChange[] spriteChangeOnDeactivate;
        [FoldoutGroup("OnDeactivate")] public AnimationChange[] animationChangeOnDeactivate;

        public UIStatus(string name)
        {
            StatusName = name;
        }

        public void Activate()
        {
            foreach (var go in showOnActivate)
            {
                go.SetActive(true);
            }
            foreach (var go in hideOnActivate)
            {
                go.SetActive(false);
            }
            foreach (var cc in colorChangeOnActivate)
            {
                cc.graphic.color = cc.color.color;
            }
            foreach (var sc in spriteChangeOnActivate)
            {
                sc.image.sprite = sc.sprite;
            }
            foreach (var ac in animationChangeOnActivate)
            {
                ac.Play();
            }
        }

        public void Deactivate()
        {
            foreach (var go in showOnDeactivate)
            {
                go.SetActive(true);
            }
            foreach (var go in hideOnDeactivate)
            {
                go.SetActive(false);
            }
            foreach (var cc in colorChangeOnDeactivate)
            {
                cc.graphic.color = cc.color.color;
            }
            foreach (var sc in spriteChangeOnDeactivate)
            {
                sc.image.sprite = sc.sprite;
            }
            foreach (var ac in animationChangeOnDeactivate)
            {
                ac.Play();
            }
        }


        [Serializable]
        public struct ColorChange
        {
            public Graphic graphic;
            public ColorSo color;
        }

        [Serializable]
        public struct SpriteChange
        {
            public Image image;
            public Sprite sprite;
        }

#if UNITY_EDITOR
        [HorizontalGroup("Split", 0.5f), Button("表示", ButtonSizes.Small)]
        public void ActivateButton() => Activate();

        [HorizontalGroup("Split", 0.5f), Button("非表示", ButtonSizes.Small)]
        public void DeactivateButton() => Deactivate();
#endif
    }
}
