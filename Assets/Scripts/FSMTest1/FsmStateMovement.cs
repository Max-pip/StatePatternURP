using UnityEngine;

namespace Assets.Scripts.FSMTest1
{
    internal class FsmStateMovement : FsmState
    {
        protected readonly Transform Transform;
        protected readonly float Speed;

        public FsmStateMovement(Fsm fsm, Transform transform, float speed) : base(fsm)
        {
            Transform = transform;
            Speed = speed;
        }

        public override void Update()
        {
            Debug.Log($"Movement ({this.GetType().Name}) state [UPDATE] with speed: {Speed}");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f )
            {
                Fsm.SetState<FsmStateWalk>();
            }

            Move(inputDirection);
        }

        protected Vector2 ReadInput()
        {
            var inputHorizontal = Input.GetAxis("Horizontal");
            var inputVertical = Input.GetAxis("Vertical");
            var inputDirection = new Vector2(inputHorizontal, inputVertical);
        
            return inputDirection;
        }

        protected virtual void Move(Vector2 inputDirection)
        {
            Transform.position += new Vector3(inputDirection.x, 0, inputDirection.y) * (Speed * Time.fixedDeltaTime);
        }
    }
}
