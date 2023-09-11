using UnityEngine;

namespace Assets.Scripts.FSMTest2
{
    public class WalkState : FsmState
    {
        public WalkState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Update()
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                _stateSwitcher.SwitchState<IdleState>();
            }
        }
    }
}
