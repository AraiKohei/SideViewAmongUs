using UnityEngine;

namespace PPD
{
    // プロジェクトごとに自由に変えちゃってね
    public static class UtilInput
    {
        static Vector3 touchPos;
        public static Vector3 GetInputDirection()
        {
            var v = Vector3.zero;
            //Key
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    v.x -= 1;
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    v.x += 1;
                }
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    v.z -= 1;
                }
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    v.z += 1;
                }
            }

            //Pointer
            {
                if (Input.GetMouseButtonDown(0))
                {
                    touchPos = Input.mousePosition;
                }

                if (Input.GetMouseButton(0))
                {
                    var vector = Input.mousePosition - touchPos;
#if UNITY_EDITOR
                    vector *= Data.Templates.sensivityOnEditor;
#endif
                    var max = Screen.width * Data.Templates.fingerRange;
                    var ans = vector / max;
                    v.x += ans.x;
                    v.z += ans.y;
                }
            }

            if (v.sqrMagnitude > 1)
            {
                v.Normalize();
            }
            return v;
        }

    }
}

