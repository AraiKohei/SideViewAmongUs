using System;
using UnityEngine;

namespace PPD
{
    abstract class _PPButton_ExtraFunction { internal abstract Type Type { get; } }
    class PPButton_ExtraFunction<T> : _PPButton_ExtraFunction
    where T : PPButton_ExtraFunction
    {
        internal override Type Type => typeof(T);
    }

    /// <summary>
    /// 外部から初期値変える時はAwakeタイミングで初期値を設定してください。
    /// </summary>
    public abstract class PPButton_ExtraFunction : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<PPButton>().extraFunction = this;
        }

        public abstract void OnClick();
    }
}