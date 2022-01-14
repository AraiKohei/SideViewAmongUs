using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PPD
{
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        void Update()
        {
            this.transform.position = Vector3.Lerp(this.transform.position, target.position, 0.2f);
        }
    }
}