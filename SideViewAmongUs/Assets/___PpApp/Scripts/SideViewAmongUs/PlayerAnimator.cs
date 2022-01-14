using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PPD
{
    public class PlayerAnimator : MonoBehaviour
    {
        public Animator animator;
        public Transform flip;
        Vector3 lastPos;
        bool toRight = true;
        PlayerMove playerMove;
        void Start()
        {
            playerMove = this.gameObject.GetComponent<PlayerMove>();
        }
        void Update()
        {
            var move = playerMove.move;

            var moveX = move.x.Abs() / Time.deltaTime;

            if ((move.x > 0 && !toRight) || (move.x < 0 && toRight))
            {
                FlipSide();
            }
            animator.SetFloat("moveX", moveX);

            animator.SetBool("isGround", playerMove.onGround);
            animator.SetFloat("moveY", move.y);

            lastPos = this.transform.position;
        }

        private void FlipSide()
        {
            toRight = !toRight;
            flip.SetLocalScaleX(toRight ? 1 : -1);
        }
    }
}