using System.Threading.Tasks;

namespace StateMachine.States
{
    public sealed class LobbyState : BaseState<LobbyState.Params>
    {
        public sealed record Result(float Random) : BaseResult;

        public sealed record Params(int Count) : BaseParams;

        protected override async Task<BaseResult> InnerProcess()
        {
            UnityEngine.Debug.Log($"LobbyState :: Process :: {stateParams.Count}");
            await Task.Delay(5000);
            return new Result(UnityEngine.Random.Range(0f, 1f));
        }
        
        public override Task Leave()
        {
            UnityEngine.Debug.Log($"LobbyState :: Leave");
            return base.Leave();
        }
    }
}