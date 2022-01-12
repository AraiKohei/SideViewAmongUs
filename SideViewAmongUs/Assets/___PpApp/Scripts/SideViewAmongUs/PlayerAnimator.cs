using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PPD
{
    public class PlayerAnimator : MonoBehaviour
    {
        public Animator animator;
        Vector3 lastPos;
        void Update()
        {
            var move = this.transform.position - lastPos;

            var moveX = move.x.Abs() / Time.deltaTime;

            animator.SetFloat("moveX", moveX);

            lastPos = this.transform.position;
        }
    }
}