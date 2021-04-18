using UnityEngine;
using Zenject;

namespace MyrddinsOwl.Core
{
    public class Container : IContainer
    {
        private DiContainer _container;

        public Container(DiContainer container)
        {
            _container = container;
        }

        public T InstantiatePrefabForComponent<T>(Object prefab) =>  _container.InstantiatePrefabForComponent<T>(prefab);

        public T Resolve<T>() => _container.Resolve<T>();
    }
}