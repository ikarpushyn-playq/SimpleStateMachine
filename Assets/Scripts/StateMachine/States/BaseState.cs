using System;
using System.Threading.Tasks;
using StateMachine.Interfaces;

namespace StateMachine.States
{
    public abstract class BaseState<TParams> : IBaseState where TParams : BaseParams
    {
        private BaseParams @params;
        private BaseResult stateResult;
        protected TParams stateParams => (TParams) @params;
        
        public virtual void Enter(BaseParams value) => @params = value;

        public async Task<BaseResult> Process()
        {
            stateResult = await InnerProcess();
            return stateResult;
        }

        protected abstract Task<BaseResult> InnerProcess();
        public virtual Task Leave() => Task.CompletedTask;
    }
}