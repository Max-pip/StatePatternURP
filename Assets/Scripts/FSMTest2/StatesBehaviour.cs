using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.FSMTest2
{
    public class StatesBehaviour : MonoBehaviour, IStateSwitcher
    {
        private FsmState _fsmState;
        private List<FsmState> _allStates;

        private void Start()
        {
            _allStates = new List<FsmState>()
            {
                new IdleState(this),
                new WalkState(this),
            };
            _fsmState = _allStates[0];
        }

        private void Update()
        {
            _fsmState.Update();
        }

        public void SwitchState<T>() where T : FsmState
        {
            var state = _allStates.FirstOrDefault(s => s is T);
            _fsmState.Stop();
            _fsmState = state;
            _fsmState.Start();
        }
    }
}
