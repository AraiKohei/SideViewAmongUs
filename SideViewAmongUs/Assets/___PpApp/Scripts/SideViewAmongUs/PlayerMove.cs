using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PPD
{
    public class PlayerMove : MonoBehaviour
    {
        Rigidbody2D rb;
        Vector3 lastPos;
        public bool onGround;
        public Vector3 move;
        float maxSpeed => Data.Ins._LevelDesigns.maxSpeed;
        float jumpPower => Data.Ins._LevelDesigns.jumpPower;
        float jumpCoolTime = 0;
        float jumpInterval = 0.5f;
        void Start()
        {
            rb = this.gameObject.GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            move = this.transform.position - lastPos;
            var speedX = move.x / Time.deltaTime;

            if (speedX.Abs() < maxSpeed)
            {
                rb.AddForce(Vector3.right * InputController.Inst.dir3D.x * 30);
            }

            lastPos = this.transform.position;

            onGround = GroundCheck();
            if (jumpCoolTime > 0) jumpCoolTime -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && onGround && jumpCoolTime <= 0)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jumpCoolTime = jumpInterval;
            }

        }

        private bool GroundCheck()
        {
            var hits = Physics2D.BoxCastAll(this.transform.position, new Vector2(0.6f, 0.04f), 0.0f, Vector2.down, 0.1f, LayerMask.GetMask("Field", "Player"));
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject == gameObject) continue;
                if (Vector2.Dot(Vector2.up, hit.normal) < 0.75f) continue;
                return true;
            }

            return false;
        }
    }
}