using System;
using StateMachine.Interfaces;
using StateMachine.States;

namespace StateMachine
{
    public sealed record StateTransition(IBaseState From, IBaseState To) : IConditionParams
    {
        private Func<BaseResult, bool> completeResult = _ => true;
        private Func<BaseResult, BaseParams> completeParamsResult;

        public bool Complete(BaseResult result, out BaseParams @params)
        {
            @params = default;
            if (!completeResult(result))
            {
                return false;
            }

            @params = completeParamsResult(result);
            return true;
        }

        public IParams WhenCompleteResult<TResult>(Func<TResult, bool> condition) where TResult : BaseResult
        {
            completeResult = result => condition((TResult) result);
            return this;
        }

        public void WithParams(BaseParams @params) => WithParams(() => @params);
        public void WithParams(Func<BaseParams> convert) => completeParamsResult = _ => convert();

        public void WithParams<TResult>(Func<TResult, BaseParams> convert) where TResult : BaseResult =>
            completeParamsResult = result => convert((TResult) result);
    }
}