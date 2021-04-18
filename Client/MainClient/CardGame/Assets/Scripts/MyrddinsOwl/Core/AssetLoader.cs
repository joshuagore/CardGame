using System.Threading.Tasks;
using UnityEngine;

namespace MyrddinsOwl.Core
{
    public class AssetLoader
    {
        public async Task<T> Load<T>(string path) where T : Object
        {
            await Task.Yield();
            return Resources.Load<T>(path);
        }
    }
}