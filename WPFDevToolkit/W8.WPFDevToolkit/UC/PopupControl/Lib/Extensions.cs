using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace W8.WPFDevToolkit.UC.PopupControl.Lib
{
    public static class Extensions
    {
        public static Task<A> EventToTaskAsync<A>(Action<EventHandler<A>> adder, Action<EventHandler<A>> remover)
        {
            System.Threading.Tasks.TaskCompletionSource<A> tcs = new TaskCompletionSource<A>();
            EventHandler<A> onComplete = null;
            onComplete = (s, e) =>
            {
                remover(onComplete);
                tcs.SetResult(e);
            };
            adder(onComplete);
            return tcs.Task;
        }

        public static Task BeginAsync(this Storyboard storyboard)
        {
            return EventToTaskAsync<object>(
                    e => { storyboard.Completed += e; storyboard.Begin(); },
                    e => storyboard.Completed -= e);
        }
    }
}
