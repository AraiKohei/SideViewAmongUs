using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Playables;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PPD
{
    public static class EX_Transform
    {
        public static void SetLocalScaleX(this Transform transform, float value)
        {
            var v = transform.localScale;
            v.x = value;
            transform.localScale = v;
        }

        public static void SetLocalScaleY(this Transform transform, float value)
        {
            var v = transform.localScale;
            v.y = value;
            transform.localScale = v;
        }

        public static void SetLocalScaleZ(this Transform transform, float value)
        {
            var v = transform.localScale;
            v.z = value;
            transform.localScale = v;
        }

        public static void SetLocalPositionX(this Transform transform, float value)
        {
            var v = transform.localPosition;
            v.x = value;
            transform.localPosition = v;
        }

        public static void SetLocalPositionY(this Transform transform, float value)
        {
            var v = transform.localPosition;
            v.y = value;
            transform.localPosition = v;
        }

        public static void SetLocalPositionZ(this Transform transform, float value)
        {
            var v = transform.localPosition;
            v.z = value;
            transform.localPosition = v;
        }

        public static void SetPositionX(this Transform transform, float value)
        {
            var v = transform.position;
            v.x = value;
            transform.position = v;
        }

        public static void SetPositionY(this Transform transform, float value)
        {
            var v = transform.position;
            v.y = value;
            transform.position = v;
        }

        public static void SetPositionZ(this Transform transform, float value)
        {
            var v = transform.position;
            v.z = value;
            transform.position = v;
        }

        public static void AddPositionX(this Transform transform, float value)
        {
            var v = transform.localPosition;
            v.x += value;
            transform.localPosition = v;
        }

        public static void AddPositionY(this Transform transform, float value)
        {
            var v = transform.localPosition;
            v.y += value;
            transform.localPosition = v;
        }

        public static void AddPositionZ(this Transform transform, float value)
        {
            var v = transform.localPosition;
            v.z += value;
            transform.localPosition = v;
        }
    }
}
