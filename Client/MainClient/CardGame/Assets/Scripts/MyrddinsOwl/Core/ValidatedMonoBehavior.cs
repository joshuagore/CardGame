#if DEBUG
using System.Diagnostics;
#endif
using MyrddinsOwl.Debug;
using UnityEngine;

namespace MyrddinsOwl.Core
{
    public abstract class ValidatedMonoBehaviour : MonoBehaviour
    {
        protected IContainer Container { get; private set; }
        
        protected virtual void Awake()
        {
            ValidateFields();
        }

        [Conditional("DEBUG")]
        private void ValidateFields()
        {
            var fieldInfos = ValidationHelper.ListOfPropertiesFromInstance(this);
                        
            foreach (var fieldInfo in fieldInfos)
            {
                var obj = fieldInfo.GetValue(this);

                if (fieldInfo.FieldType.IsSubclassOf(typeof(MonoBehaviour)) && obj == null)
                {
                    LogIfMissing(obj, fieldInfo.ToString());
                }
            }
        }
        
        [Conditional("DEBUG")]
        private void LogIfMissing(object field, string fieldName)
        {
            if (field == null)
            {
                Logger.Instance.Error($"'{fieldName}' on '{GetType().Name}' is not assigned.");
            }
        }
    }
}