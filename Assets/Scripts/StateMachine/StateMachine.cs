using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StateMachine.Interfaces;
using StateMachine.States;

namespace StateMachine
{
    public sealed class StateMachine
    {
        private readonly List<IBaseState> states = new();
        private readonly List<StateTransition> transitions = new();
        private IBaseState currentState;

        public void AddState<TState>() where TState : IBaseState, new() =>
            states.Add(new TState());

        public IConditionParams Transition<TStateFrom, TStateTo>()
            where TStateFrom : IBaseState where TStateTo : IBaseState
        {
            var transition = new StateTransition(GetState<TStateFrom>(), GetState<TStateTo>());
            transitions.Add(transition);
            return transition;
        }

        public async Task Start<TState>(BaseParams @params) where TState : IBaseState
        {
            currentState = GetState<TState>();
            currentState.Enter(@params);

            while (currentState is not null)
            {
                BaseResult result = await currentState.Process();
                await currentState.Leave();

                IBaseState state = currentState;
                currentState = null;
                foreach (StateTransition transition in transitions.Where(t => t.From == state))
                {
                    if (!transition.Complete(result, out BaseParams baseParams))
                    {
                        continue;
                    }

                    currentState = transition.To;
                    currentState.Enter(baseParams);
                }
            }
        }

        private TState GetState<TState>() where TState : IBaseState
            => (TState) GetStateInterface<TState>();

        private IBaseState GetStateInterface<TState>() where TState : IBaseState
        {
            foreach (IBaseState innerState in states.Where(s => s is TState))
            {
                return innerState;
            }

            throw new Exception("No State");
        }
    }
}