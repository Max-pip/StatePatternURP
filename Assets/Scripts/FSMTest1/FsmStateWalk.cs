using UnityEngine;

namespace Assets.Scripts.FSMTest1
{
    internal class FsmStateWalk : FsmStateMovement
    {
        public FsmStateWalk(Fsm fsm, Transform transform, float speed) : base(fsm, transform, speed)
        {
        }

        public override void Enter()
        {
            Debug.Log("Walk State");
        }

        public override void Update()
        {
            //Debug.Log($"Walk state [UPDATE] with {Speed}");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Fsm.SetState<FsmStateRun>();
            }

            Move(inputDirection);
        }
    }
}
