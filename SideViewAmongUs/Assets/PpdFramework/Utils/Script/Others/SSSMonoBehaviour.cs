using UnityEngine;
using UnityEngine.Assertions;

namespace PPD
{
    /// <summary>
    /// Scene-Shared-Singleon MonoBehaviour.
    /// 
    /// 自動的に Dont Destroy On Load 行きになります。加えて２つ目が警告なしに無視されます。
    /// </summary>
    public abstract class SSSMonoBehaviour<T> : MonoBehaviour
    where T : SSSMonoBehaviour<T>
    {
        public static T Inst { get; private set; }
#if UNITY_EDITOR
        static string GenSceneName;
        static int GenSceneIndex;
#endif

        void Awake()
        {
            if (Inst == null)
            {
                Inst = this as T;
#if UNITY_EDITOR
                GenSceneName = this.gameObject.scene.name;
                GenSceneIndex = this.gameObject.scene.buildIndex;
#endif
                this.transform.parent = null;
                DontDestroyOnLoad(this);
                OnUnityAwake();
                return;
            }
            else
            {
#if UNITY_EDITOR
                Assert.IsFalse(
                    GenSceneName == this.gameObject.scene.name
                 && GenSceneIndex == this.gameObject.scene.buildIndex,
                 $"SSSMonoBehaviour:同一シーンで作られています。同じコンポーネントが２つあるかも？ {this.name}");
#endif
                this.SetActiveSelf(false);
                return;
            }
        }

        void OnDestroy()
        {
            OnUnityDestroy();
        }

        protected abstract void OnUnityAwake();
        protected virtual void OnUnityDestroy() { }
    }
}