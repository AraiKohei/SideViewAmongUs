using System;
using UnityEngine;
using PPD.ProviderInterfaces;

namespace PPD
{
    public static class EX_Provider
    {
        public static void Awake_SetProviderToChildren<T>(this T self, bool includeInactice = true)
        where T : Component, IProvider
        {
            foreach (var c in self.GetComponentsInChildren<IController<T>>(includeInactice))
            {
                c.SetProvider(self);
            }
        }

        [Obsolete("Use Awake_SetProviderToChildren() Instead.")]
        public static void SetChildrenProvider<T>(this T self, bool includeInactice = true)
            where T : Component, IProvider
        {
            foreach (var c in self.GetComponentsInChildren<IController<T>>(includeInactice))
            {
                c.SetProvider(self);
            }
        }
    }

    namespace ProviderInterfaces
    {
        public interface IProvider { }

        public interface IController<T>
        where T : IProvider
        {
            void SetProvider(T Provider);
        }
    }

    public abstract class MonoBehaviour_Provider : MonoBehaviour, IProvider { }
    public abstract class MonoBehaviour_Controller<T> : MonoBehaviour, IController<T>
    where T : MonoBehaviour, IProvider
    {
        public T Provider { get; private set; }
        public void SetProvider(T Provider)
        {
            this.Provider = Provider;
            UnityAwake();
        }

        protected abstract void UnityAwake();

        /// <summary>
        /// Providerと同じ階層にAddComponentしたときに、このコンポーネントをその直下に移動させます。
        /// </summary>
        protected virtual void Reset()
        {
            UNITY_EDITOR.Common.MoveJustBelow<T>(this, false);
        }
    }

    // ---------------------------------------------------
    // ---------------------------------------------------
    // Obsolete
    // ---------------------------------------------------
    // ---------------------------------------------------

    [Obsolete("Use IController Instead.")]
    public interface IFi5Controller<T>
    where T : Component, IFi5Provider
    {
        T Provider { get; set; }
    }

    [Obsolete("Use MonoBehaviour_Controller Instead.")]
    public class Fi5ControllerMonoBehaviour<T> : MonoBehaviour, IFi5Controller<T>
    where T : Component, IFi5Provider
    {
        public T Provider { get; set; }
    }

    public static class EX_Fi5Provider
    {
        /// <summary>
        /// [Recommend] Call it on a Provider's Awake.
        /// </summary>
        public static void SetChildrenProvider<T>(this T self, bool includeInactice = true)
        where T : Component, IFi5Provider
        {
            throw new ArgumentException("Use IProvider Instead.");
        }
    }

    [Obsolete("Use IProvider Instead.")]
    public interface IFi5Provider { }
}
