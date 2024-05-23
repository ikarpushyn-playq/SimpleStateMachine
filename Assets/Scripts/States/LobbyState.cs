using Unity.Mathematics;

namespace States
{
    public sealed class LobbyState : BaseState<LobbyState.Params, LobbyState.Result>
    {
        public sealed record Result(float Random) : BaseResult;

        public sealed record Params(int Count) : BaseParams;
        
        public override void Enter()
        {
            UnityEngine.Debug.Log($"LobbyState :: Enter :: {stateParams.Count}");
            SetResult(new Result(UnityEngine.Random.Range(0f, 1f)));
        }
        
        public override void Leave()
        {
            UnityEngine.Debug.Log("LobbyState :: Leave");
        }
    }
}