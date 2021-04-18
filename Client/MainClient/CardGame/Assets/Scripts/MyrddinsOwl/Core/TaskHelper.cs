using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MyrddinsOwl.Core
{
    public static class TaskHelper
    {
        public static void CheckCancel( CancellationToken ct, 
            [CallerMemberName] string callerName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (ct.IsCancellationRequested)
            {
                throw new TaskCanceledException(
                    $"<color=yellow>Cancelled</color> <color=red>{callerName}</color>\n" +
                    $"        at <color=lightblue>{sourceFilePath}:{sourceLineNumber}</color>");
            }
        }
    }
}