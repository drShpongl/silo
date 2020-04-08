using System;
using System.Threading.Tasks;
using igrains;
using Microsoft.Extensions.Logging;

namespace grains
{
    public class CrudGrainBase<T> : Orleans.Grain, ICrudGrainBase<T>
    {
        private readonly ILogger logger;
        private T State;

        public override async Task OnActivateAsync()
        {
            // State = Activator.CreateInstance<T>();
            await Task.Delay(0);
        }

        public override async Task OnDeactivateAsync()
        {
            await Task.Delay(0);
        }

        // public override void Participate(Orleans.Runtime.IGrainLifecycle lifecycle)
        // {
        //     lifecycle.Subscribe("", 0, ILifecycleObserver observer);
        // }

        public CrudGrainBase(ILogger<CrudGrainBase<T>> logger)
        {
            this.logger = logger;
        }

        public Task<T> Get()
        {
            return Task.FromResult(this.State);
        }

        public Task<bool> Save(T state)
        {
            this.State = state;
            return Task.FromResult(true);
        }
    }
}
