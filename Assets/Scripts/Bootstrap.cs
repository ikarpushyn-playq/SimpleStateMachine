using StateMachine.States;
using UnityEngine;

public sealed class Bootstrap : MonoBehaviour
{
    private async void Start()
    {
        var stateMachine = new StateMachine.StateMachine();

        stateMachine.AddState<LobbyState>();
        stateMachine.AddState<GameState>();
        stateMachine.AddState<WinState>();

        stateMachine
            .Transition<LobbyState, GameState>()
            .WhenCompleteResult((LobbyState.Result result) => result.Random > 0.7f)
            .WithParams(new GameState.Params(2));

        stateMachine
            .Transition<LobbyState, WinState>()
            .WhenCompleteResult((LobbyState.Result result) => result.Random <= 0.7f)
            .WithParams((LobbyState.Result result) => new WinState.Params(result.Random));

        stateMachine
            .Transition<WinState, LobbyState>()
            .WithParams(new LobbyState.Params(88));

        // set state
        await stateMachine.Start<LobbyState>(new LobbyState.Params(1));
    }
}