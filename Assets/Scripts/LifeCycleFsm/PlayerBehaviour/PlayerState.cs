using UnityEngine;

namespace Assets.Scripts.LifeCycleFsm

{
    public abstract class PlayerState
    {
        protected readonly Player Player;
        protected readonly PlayerAnimation PlayerAnimation;
        protected readonly PlayerStateMachine PlayerStateMachine;

        public PlayerState(Player player, PlayerAnimation playerAnimation, PlayerStateMachine playerStateMachine)
        {
            Player = player;
            PlayerAnimation = playerAnimation;
            PlayerStateMachine = playerStateMachine;
        }

        public abstract void Start();

        public abstract void Stop();

        public abstract void Update();

        protected abstract void MoveToTarget(Vector3 targetPos);
    }
}