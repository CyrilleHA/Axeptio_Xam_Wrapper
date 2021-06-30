using System;
namespace Tools.ViewModels
{
    public struct BusyContext : IDisposable
    {
        public Action OnFinished;

        public BusyContext(Action onFinished)
        {
            this.OnFinished = onFinished;
        }

        public void Dispose()
        {
            this.OnFinished?.Invoke();
        }
    }
}
