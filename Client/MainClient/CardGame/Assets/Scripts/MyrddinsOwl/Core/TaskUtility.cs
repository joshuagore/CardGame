using System;
using System.Threading.Tasks;
using UnityEngine;

namespace MyrddinsOwl.Core
{
    public static class TaskUtility
    {
        public static async Task AsyncTask(Task task)
        {
            try
            {
                await task;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}