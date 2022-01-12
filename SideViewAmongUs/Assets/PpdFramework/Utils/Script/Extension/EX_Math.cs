using UnityEngine;

namespace PPD
{
    public static class EX_Math
    {
        /// <summary>
        /// +1か-1に変換する。
        /// </summary>
        public static int AsP1M1(in this bool value) => value ? 1 : -1;
        /// <summary>
        /// +1か-1に変換する。
        /// </summary>
        public static int AsP1M1(in this int value) => (value == 0) ? 0 : (value > 0 ? 1 : -1);
        /// <summary>
        /// +1か-1に変換する。
        /// </summary>
        public static int AsP1M1(in this float value) => (value == 0) ? 0 : (value > 0 ? 1 : -1);
        public static bool IsSameSign(in this int a, int b)
         => (a > 0 && b > 0) || (a < 0 && b < 0) || (a == 0 && b == 0);
        public static int Abs(this int v) => Mathf.Abs(v);
        public static float Abs(this float v) => Mathf.Abs(v);
    }
}
