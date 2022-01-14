using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace PPD
{
    // プロジェクトごとに自由に変えちゃってね
    public class InputController : SingletonMonoBehaviour<InputController>
    {
        protected override void UnityAwake() { }
        public Vector3 dir3D;
        void Update()
        {
            dir3D = UtilInput.GetInputDirection();
        }
    }
}

