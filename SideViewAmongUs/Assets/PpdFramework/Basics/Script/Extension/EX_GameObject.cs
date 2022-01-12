using UnityEngine;
namespace PPD
{
    public static class EX_GameObject
    {
        public static void SetActiveSelf(this Component c, bool flg)
        {
            var o = c.gameObject;
            if (o.activeSelf != flg)
            {
                o.SetActive(flg);
            }
        }

        public static void SetActiveSelf(this GameObject o, bool flg)
        {
            if (o.activeSelf != flg)
            {
                o.SetActive(flg);
            }
        }

        public static void SetEnable(this MonoBehaviour mb, bool flg)
        {
            mb.enabled = flg;
        }

        public static void SetLayer(this Component c, int number, bool applyChildren = true)
        {
            if (!applyChildren)
            {
                c.gameObject.layer = number;
            }
            else
            {
                _SetLayer(c.transform, number);
            }
        }

        public static void SetLayer(this GameObject o, int number, bool applyChildren = true)
        {
            if (!applyChildren)
            {
                o.layer = number;
            }
            else
            {
                _SetLayer(o.transform, number);
            }
        }

        static void _SetLayer(Transform t, int number)
        {
            t.gameObject.layer = number;
            foreach (Transform child in t)
            {
                _SetLayer(child, number);
            }
        }

        /// <summary>
        /// SetActiveSelf(false); を推奨します
        /// </summary>
        public static void DestroyComponent(this Component c)
        {
            GameObject.Destroy(c);
        }

        /// <summary>
        /// SetActiveSelf(false); を推奨します
        /// </summary>
        public static void DestroyInstance(this Component c)
        {
            GameObject.Destroy(c.gameObject);
        }

        /// <summary>
        /// SetActiveSelf(false); を推奨します
        /// </summary>
        public static void DestroyInstance(this GameObject o)
        {
            GameObject.Destroy(o);
        }
    }
}
