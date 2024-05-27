using System.Threading.Tasks;

namespace StateMachine.States
{
    public sealed class WinState : BaseState<WinState.Params>
    {
        public sealed record Result(int Status) : BaseResult;

        public sealed record Params(float Random) : BaseParams;

        protected override async Task<BaseResult> InnerProcess()
        {
            UnityEngine.Debug.Log($"WinState :: Process :: {stateParams.Random}");
            await Task.Delay(5000);
            return new Result(99);
        }

        public override Task Leave()
        {
            UnityEngine.Debug.Log($"WinState :: Leave");
            return base.Leave();
        }
    }
}