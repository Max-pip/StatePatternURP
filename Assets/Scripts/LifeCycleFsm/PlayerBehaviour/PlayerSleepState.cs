using UnityEngine;

namespace Assets.Scripts.LifeCycleFsm
{
    internal class PlayerSleepState : PlayerState
    {
        private float _distance;
        private Vector3 _direction;

        public PlayerSleepState(Player player, PlayerAnimation playerAnimation, PlayerStateMachine playerStateMachine) : base(player, playerAnimation, playerStateMachine)
        {
        }

        public override void Start()
        {
            Debug.Log("Enter in SLEEP_STATE");
            PlayerAnimation.ChangeAnimation(PlayerAnimation.PlayerWalk);
            PlayerAnimation.OnEndAnim += EndThisState;
        }

        public override void Update()
        {
            _distance = (Player.SleepPlace.position - Player.transform.position).magnitude;
            _direction = Player.SleepPlace.position - Player.transform.position;

            if (_distance > 0.2f ) 
            {
                MoveToTarget(Player.SleepPlace.position);
            } else
            {
                Player.transform.rotation = Player.SleepPlace.rotation;
                PlayerAnimation.ChangeAnimation(PlayerAnimation.PlayerSleep);
            }
        }

        public override void Stop()
        {
            PlayerAnimation.OnEndAnim -= EndThisState;
            PlayerAnimation.ChangeAnimation(PlayerAnimation.PlayerWalk);
        }

        protected override void MoveToTarget(Vector3 targetPos)
        {
            Quaternion rotation = Quaternion.LookRotation(_direction);
            Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, rotation, Player.RotationSpeed * Time.deltaTime);
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, targetPos, Player.Speed * Time.deltaTime);
        }

        private void EndThisState()
        {
            Player.Energy += 100f;
            SwitchToNextState();
        }
        private void SwitchToNextState()
        {
            if (Player.Eat <= 30f)
            {
                PlayerStateMachine.SetState<PlayerEatState>();
            }
            else
            {
                PlayerStateMachine.SetState<PlayerWanderState>();
            }
        }
    }
}