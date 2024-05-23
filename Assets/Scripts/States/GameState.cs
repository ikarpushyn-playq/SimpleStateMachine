namespace States
{
    public sealed class GameState : BaseState<GameState.Params, GameState.Result>
    {
        public sealed record Result(int Status) : BaseResult;
        public sealed record Params(int Status) : BaseParams;

        public override void Enter()
        {
            UnityEngine.Debug.Log($"GameState :: Enter :: {stateParams.Status}");
            SetResult(new Result(99));
        }
    }
}
