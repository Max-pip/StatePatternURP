using UnityEngine;

namespace Assets.Scripts.FSMTest2
{
    public class IdleState : FsmState
    {
        public IdleState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Update()
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                _stateSwitcher.SwitchState<WalkState>();
            }
        }
    }
}
