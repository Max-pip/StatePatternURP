using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.LifeCycleFsm
{
    public class PlayerStateMachine
    {
        public PlayerState CurrentPlayerState { get; set; }

        private List<PlayerState> _states = new List<PlayerState>();

        public void AddState(PlayerState state)
        {
            _states.Add(state);
        }

        public void SetState<T>() where T : PlayerState
        {
            var state = _states.FirstOrDefault(s => s is T);
            CurrentPlayerState?.Stop();
            CurrentPlayerState = state;
            CurrentPlayerState.Start();
        }

    }
}
