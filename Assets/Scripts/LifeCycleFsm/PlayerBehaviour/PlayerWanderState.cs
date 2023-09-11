using UnityEngine;

namespace Assets.Scripts.LifeCycleFsm
{
    internal class PlayerWanderState : PlayerState
    {
        private readonly LifeRadius _lifeRadius;

        private float _distance;
        private Vector3 _targetPoint;
        private Vector3 _direction;

        public PlayerWanderState(LifeRadius lifeRadius ,Player player, PlayerAnimation playerAnimation, PlayerStateMachine playerStateMachine) 
        : base(player, playerAnimation, playerStateMachine)
        {
            _lifeRadius = lifeRadius;
        }
        public override void Start()
        {
            Debug.Log("Enter in WANDER_STATE");
            PlayerAnimation.ChangeAnimation(PlayerAnimation.PlayerWalk);
            _targetPoint = _lifeRadius.SpawnRandomPointWithinRadius(Player.transform.position.y);
        }

        public override void Update()
        {
            PlayerWander();

            SwitchToNextState();
        }

        public override void Stop()
        {
            
        }


        private void PlayerWander()
        {
            if (_targetPoint != null)
            {
                _distance = (_targetPoint - Player.transform.position).magnitude;
                _direction = _targetPoint - Player.transform.position;

                if (_distance > 1f)
                {
                    MoveToTarget(_targetPoint);
                }
                else
                {
                    _targetPoint = _lifeRadius.SpawnRandomPointWithinRadius(Player.transform.position.y);
                }
            }
        }

        protected override void MoveToTarget(Vector3 targetPos)
        {
            Quaternion rotation = Quaternion.LookRotation(_direction);
            Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, rotation, Player.RotationSpeed * Time.deltaTime);
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, targetPos, Player.Speed * Time.deltaTime);
        }

        private void SwitchToNextState()
        {
            if (Player.Eat <= 30f)
            {
                PlayerStateMachine.SetState<PlayerEatState>();
            }
            else if (Player.Energy <= 30f)
            {
                PlayerStateMachine.SetState<PlayerSleepState>();
            }
        }
    }
}
