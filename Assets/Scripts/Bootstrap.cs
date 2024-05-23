using States;
using UnityEditor;
using UnityEngine;

public sealed class Bootstrap : MonoBehaviour
{
    void Start()
    {
        var stateMachine = new StateMachine();
        
        // add states
        stateMachine.AddState<LobbyState, LobbyState.Params, LobbyState.Result>();
        stateMachine.AddState<GameState, GameState.Params, GameState.Result>();
        
        // complete events
        stateMachine.WhenComplete<LobbyState>(state =>
        {
            UnityEngine.Debug.Log($"LobbyState :: Complete :: {state.StateResult.Random}");
            if (state.StateResult.Random > 0.5f)
            {
                stateMachine.SetState<GameState>(new GameState.Params(2));
            }
            else
            {
                
            }
        });
        
        stateMachine.WhenComplete<GameState>(state =>
        {
            UnityEngine.Debug.Log($"GameState :: Complete :: {state.StateResult.Status}");
            
            LobbyState.Result lobbyResult = stateMachine.GetState<LobbyState>().StateResult;
            UnityEngine.Debug.Log($"lobbyResult :: {lobbyResult.Random}");
        });
        

        // set state
        stateMachine.SetState<LobbyState>(new LobbyState.Params(1));
    }
}
