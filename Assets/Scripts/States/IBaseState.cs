using System;

namespace States
{
    public interface IBaseState
    {
        public void SetParams(BaseParams value);
        public void Enter();
        public void Leave();
        void SetComplete(Action action);
    }
}