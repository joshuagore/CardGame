#if DEBUG
using System.Reflection;

namespace MyrddinsOwl.Debug
{
    public static class ValidationHelper
    {
        public static FieldInfo[] ListOfPropertiesFromInstance(object instanceOfObject)
        {
            FieldInfo[] fields = instanceOfObject.GetType().GetFields( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return fields;
        }
    }
}

#else
using System;
namespace MyrddinsOwl.Debug
{
    public interface IValidationObject
    {
        public IValidationObject GetValue(object obj);
        public Type FieldType { get; }
    }
    
    public class ValidationObject : IValidationObject
    {
        public IValidationObject GetValue(object obj)
        {
            return this;
        }

        public Type FieldType => this.GetType();
    }

    public static class ValidationHelper
    {
        public static IValidationObject[] ListOfPropertiesFromInstance(object instanceOfObject)
        {
            return Array.Empty<IValidationObject>();
        }
    }
}
#endif