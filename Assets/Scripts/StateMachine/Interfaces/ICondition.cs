using System;
using StateMachine.States;

namespace StateMachine.Interfaces
{
    public interface ICondition
    {
        IParams WhenCompleteResult<TResult>(Func<TResult, bool> condition) where TResult : BaseResult;
    }
}