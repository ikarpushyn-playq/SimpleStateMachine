using System;

namespace States
{
    public abstract class BaseState<TParams, TResult> : IBaseState
        where TParams : BaseParams
        where TResult : BaseResult
    {
        private BaseParams baseParams;
        private BaseResult baseResult;
        private Action complete;

        protected TParams stateParams => (TParams) baseParams;
        public TResult StateResult => (TResult) baseResult;
        public void SetParams(BaseParams value) => baseParams = value;
        protected void SetResult(BaseResult value)
        {
            baseResult = value;
            complete?.Invoke();
        }
        public void SetComplete(Action action) => complete = action;

        public virtual void Enter()
        {
        }

        public virtual void Leave()
        {
        }
    }
}