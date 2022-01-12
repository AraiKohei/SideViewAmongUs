using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace PPD
{
    public class FingerUI : SingletonMonoBehaviour<FingerUI>
    {
        public Transform viewTf;
        public Transform fingerTf;
        public Image circle;
        public Image finger;

        protected override void UnityAwake()
        {
        }

        private void Start()
        {
            if (Data.Templates.gameMode != GameMode.Capture)
            {
                this.SetActiveSelf(false);
            }
        }

        void LateUpdate()
        {
            float targetR = 0f;
            float targetA = 0f;

            if (Input.GetMouseButton(0))
            {
                targetR = 30;
                targetA = 0.5f;
            }

            fingerTf.rotation = Quaternion.Lerp(fingerTf.rotation, Quaternion.Euler(0, 0, targetR), 0.2f);

            var color = circle.color;
            color.a = Mathf.Lerp(color.a, targetA, 0.1f);
            circle.color = color;

            viewTf.position = Input.mousePosition;
        }

        public void FadeOut()
        {
            if (this.enabled)
            {
                this.enabled = false;
                finger.DOFade(0, 1);
            }
        }
    }
}