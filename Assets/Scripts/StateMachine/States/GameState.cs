using System.Threading.Tasks;

namespace StateMachine.States
{
    public sealed class GameState : BaseState<GameState.Params>
    {
        public sealed record Result(int Status) : BaseResult;

        public sealed record Params(int Status) : BaseParams;

        protected override async Task<BaseResult> InnerProcess()
        {
            UnityEngine.Debug.Log($"GameState :: Process :: {stateParams.Status}");
            await Task.Delay(5000);
            return new Result(99);
        }

        public override Task Leave()
        {
            UnityEngine.Debug.Log($"GameState :: Leave");
            return base.Leave();
        }
    }
}