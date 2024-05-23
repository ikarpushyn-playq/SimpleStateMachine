using System;
using System.Collections.Generic;
using System.Linq;
using States;

public sealed class StateMachine
{
    private readonly List<IBaseState> innerStates = new();
    private IBaseState currentState;

    public void AddState<TState, TParams, TResult>()
        where TState : BaseState<TParams, TResult>, new()
        where TParams : BaseParams
        where TResult : BaseResult
    {
        innerStates.Add(new TState());
    }

    public void SetState<TState>(BaseParams baseParams) where TState : IBaseState
    {
        currentState?.Leave();

        currentState = GetStateInterface<TState>();
        currentState.SetParams(baseParams);
        currentState.Enter();
    }

    public void WhenComplete<TState>(Action<TState> action) where TState : IBaseState
    {
        var state = GetState<TState>();
        state.SetComplete(() =>
        {
            action?.Invoke(state);
        });
    }

    private IBaseState GetStateInterface<TState>() where TState : IBaseState
    {
        foreach (IBaseState innerState in innerStates.Where(innerState => innerState is TState))
        {
            return innerState;
        }

        throw new Exception("No State");
    }

    public TState GetState<TState>() where TState : IBaseState
        => (TState) GetStateInterface<TState>();
}