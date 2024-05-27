using System.Threading.Tasks;
using StateMachine.States;

namespace StateMachine.Interfaces
{
    public interface IBaseState
    {
        Task Leave();
        Task<BaseResult> Process();
        void Enter(BaseParams value);
    }
}