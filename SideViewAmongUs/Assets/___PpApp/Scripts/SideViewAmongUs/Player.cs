using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PPD
{
    public class Player : MonoBehaviour
    {
        public Rigidbody2D rb;

        void Update()
        {
            var inputRight = 0f;
            if (Input.GetKey(KeyCode.W))
            {

            }
            if (Input.GetKey(KeyCode.A))
            {
                inputRight -= 1;
            }
            if (Input.GetKey(KeyCode.S))
            {

            }
            if (Input.GetKey(KeyCode.D))
            {
                inputRight += 1;
            }

            rb.AddForce(Vector3.right * inputRight * 50);
        }
    }
}