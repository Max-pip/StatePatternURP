
using UnityEngine;

namespace Assets.Scripts.FSMTest1
{
    public class FsmStateIdle : FsmState
    {
        public FsmStateIdle(Fsm fsm) : base(fsm) {}

        public override void Enter()
        {
            Debug.Log("Idle Start");
        }

        public override void Update()
        {
            //UnityEngine.Debug.Log("Idle state [UPDATE]");

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0f)
            {
                Fsm.SetState<FsmStateWalk>();
            }
        }
    }
}
