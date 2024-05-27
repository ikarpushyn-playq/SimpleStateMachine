using System;
using StateMachine.States;

namespace StateMachine.Interfaces
{
    public interface IParams
    {
        void WithParams(BaseParams @params);
        void WithParams(Func<BaseParams> complete);
        void WithParams<TResult>(Func<TResult, BaseParams> result) where TResult : BaseResult;
    }
}