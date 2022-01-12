using UnityEngine;

namespace PPD
{
    public static class EX_Vector
    {
        public static readonly Vector3 Faraway = new Vector3(-100_000, 0, -100_000);
        public static float MMRange(this Vector2 v2) => Random.Range(v2.x, v2.y);
        public static int MMRange(this Vector2Int v2) => Random.Range(v2.x, v2.y);

        public static void Inverse(ref this Vector2 v)
        {
            v.x = 1f / v.x;
            v.y = 1f / v.y;
        }

        public static void Inverse(ref this Vector3 v)
        {
            v.x = 1f / v.x;
            v.y = 1f / v.y;
            v.z = 1f / v.z;
        }

        public static bool ConvertAsWorldZ0(Vector3 uiPoision, out Vector3 worldTouchPoint)
        => ConvertAsWorld_ZFixed(uiPoision, out worldTouchPoint, 0);

        public static bool ConvertAsWorld_ZFixed(Vector3 uiPoision, out Vector3 touchPoint, float z)
        {
            var ray = Camera.main.ScreenPointToRay(uiPoision);
            if (ray.direction.z != 0)
            {
                var distance = Mathf.Abs((ray.origin.z - z) / ray.direction.z);
                touchPoint = ray.GetPoint(distance);

                return true;
            }
            else
            {
                touchPoint = new Vector3(0, 0, z);
                return false;
            }
        }

        public static bool ConvertAsWorldY0(Vector3 uiPoision, out Vector3 worldTouchPoint)
        => ConvertAsWorld_YFixed(uiPoision, out worldTouchPoint, 0);

        public static bool ConvertAsWorld_YFixed(Vector3 uiPoision, out Vector3 touchPoint, float y)
        => ConvertAsWorld_YFixed(Camera.main.ScreenPointToRay(uiPoision), out touchPoint, y);

        public static bool ConvertAsWorld_YFixed(Ray ray, out Vector3 point, float y)
        {
            if (ray.direction.y != 0)
            {
                var distance = Mathf.Abs((ray.origin.y - y) / ray.direction.y);
                point = ray.GetPoint(distance);
                return true;
            }
            else
            {
                point = new Vector3(0, y, 0);
                return false;
            }
        }
    }
}
