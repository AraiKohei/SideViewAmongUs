using UnityEngine;

namespace PPD
{
    public class MouseButtonTimescaleChanger : MonoBehaviour
    {
#if UNITY_EDITOR
        public bool ThisSceneOnly;
        static MouseButtonTimescaleChanger Inst;
        private void Awake()
        {
            if (ThisSceneOnly) return;

            if (Inst == null)
            {
                Inst = this;
                this.transform.parent = null;
                DontDestroyOnLoad(this);
            }
            else
            {
                enabled = false;
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Time.timeScale *= 2;
            }
            if (Input.GetMouseButtonDown(2))
            {
                Time.timeScale *= 4;
            }
            if (Input.GetMouseButtonUp(1))
            {
                Time.timeScale /= 2;
            }
            if (Input.GetMouseButtonUp(2))
            {
                Time.timeScale /= 4;
            }
        }
#endif
    }
}

