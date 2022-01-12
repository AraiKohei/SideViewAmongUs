using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace PPD
{
    // プロジェクトごとに自由に変えちゃってね
    public class InputController : PPD_MonoBehaviour
    {
        void Update()
        {
            var dir3D = UtilInput.GetInputDirection();
            if (dir3D != Vector3.zero)
            {
                // どの向きに入力されたかを検査するなら…
                // if (dir3D.x > 0.7f)
                // {
                // 
                // }
                // else if (dir3D.x < -0.7f)
                // {
                // 
                // }
                // else if (dir3D.z < -0.7f)
                // {
                // 
                // }
                // else if (dir3D.z < -0.7f)
                // {
                // 
                // }

                // 歩行処理。　不要なら削除すること。
                Move(dir3D);
            }
        }

        public void Move(Vector3 dir3D)
        {
            transform.localPosition += dir3D * Time.deltaTime * Data.Templates.characterWalkSpeed;
            var a = transform.localRotation;
            var b = Quaternion.LookRotation(dir3D);
            var t = Data.Templates.characterAdjRotParameter * Time.deltaTime;
            transform.localRotation = Quaternion.Lerp(a, b, t);
        }

        bool FullInput(Vector3 v3) => v3.sqrMagnitude == 1;
    }
}

