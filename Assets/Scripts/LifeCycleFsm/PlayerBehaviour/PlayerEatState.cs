using UnityEngine;

namespace Assets.Scripts.LifeCycleFsm
{
    internal class PlayerEatState : PlayerState
    {
        private AppleSpawner _appleSpawner;

        private float _distance;
        private GameObject _targetApple;
        private Vector3 _targetApplePos;
        private Vector3 _direction;

        public PlayerEatState(AppleSpawner appleSpawner , Player player, PlayerAnimation playerAnimation, PlayerStateMachine playerStateMachine) 
        : base(player, playerAnimation, playerStateMachine) 
        {
            _appleSpawner = appleSpawner;
        }

        public override void Start()
        {
            Debug.Log("Enter in EAT_STATE");
            PlayerAnimation.OnEndAnim += EndThisState;
            int randomInt = Random.Range(0, _appleSpawner.AppleList.Count);
            _targetApple = _appleSpawner.AppleList[randomInt];
        }

        public override void Update()
        {
            if (_targetApple != null)
            {
                _targetApplePos = _targetApple.transform.position;
                _targetApplePos.y = Player.transform.position.y;
                _distance = (_targetApplePos - Player.transform.position).magnitude;
                _direction = _targetApplePos - Player.transform.position;
            }

            if (_distance > 1f && _targetApple != null)
            {
                MoveToTarget(_targetApplePos);
            }
            else
            {
                _appleSpawner.RemoveApple(_targetApple);
                PlayerAnimation.ChangeAnimation(PlayerAnimation.PlayerEat);
            }           
        }

        public override void Stop()
        {
            PlayerAnimation.OnEndAnim -= EndThisState;
        }

        private void EndThisState()
        {
            Player.Eat += 100f;
            SwitchToNextState();
        }

        private void SwitchToNextState()
        {
            if (Player.Energy <= 30f)
            {
                PlayerStateMachine.SetState<PlayerSleepState>();
            }
            else
            {
                PlayerStateMachine.SetState<PlayerWanderState>();
            }
        }

        protected override void MoveToTarget(Vector3 targetPos)
        {
            Quaternion rotation = Quaternion.LookRotation(_direction);
            Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, rotation, Player.RotationSpeed * Time.deltaTime);
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, targetPos, Player.Speed * Time.deltaTime);
        }
    }
}
