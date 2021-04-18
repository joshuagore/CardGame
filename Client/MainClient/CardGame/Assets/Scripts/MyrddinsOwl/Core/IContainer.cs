namespace MyrddinsOwl.Core
{
    public interface IContainer
    {
        public T InstantiatePrefabForComponent<T>(UnityEngine.Object prefab);
        public T Resolve<T>();
    }
}