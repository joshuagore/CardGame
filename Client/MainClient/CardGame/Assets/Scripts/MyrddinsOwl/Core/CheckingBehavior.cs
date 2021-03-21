using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace MyrddinsOwl.Core
{
    public abstract class CheckingBehavior : MonoBehaviour
    {
        protected virtual void Awake()
        {
            ValidateFields();
        }

        [Conditional("DEBUG")]
        protected abstract void ValidateFields();

        protected void LogIfMissing(MonoBehaviour field, string fieldName)
        {
            if (field == null)
            {
                Debug.LogError($"'{fieldName}' on '{GetType().Name}' is not set.");
            }
        }
    }
}