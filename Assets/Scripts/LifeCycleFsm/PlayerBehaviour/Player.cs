using Assets.Scripts.LifeCycleFsm;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine _playerStateMachine;

    [SerializeField] private LifeRadius _lifeRadius;
    [SerializeField] private AppleSpawner _appleSpawner;
    [SerializeField] private PlayerAnimation _playerAnimator;
    [field: SerializeField] public Transform SleepPlace { get; private set; }
    [field: SerializeField] public float Speed { get; private set; } = 3f;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 5f;
    [field: SerializeField] public float EatConsumptionValue { get; private set; } = 7f;
    [field: SerializeField] public float EnergyConsumptionValue { get; private set; } = 4f;
    public float Eat { get; set; } = 100f;
    public float Energy { get; set; } = 100f;


    private void Start()
    {
        _playerStateMachine = new PlayerStateMachine();

        _playerStateMachine.AddState(new PlayerWanderState(_lifeRadius ,this, _playerAnimator, _playerStateMachine));
        _playerStateMachine.AddState(new PlayerEatState(_appleSpawner ,this, _playerAnimator, _playerStateMachine));
        _playerStateMachine.AddState(new PlayerSleepState(this, _playerAnimator, _playerStateMachine));

        _playerStateMachine.SetState<PlayerWanderState>();
    }

    private void Update()
    {
        CheckLimitLifeValues();
        Eat -= EatConsumptionValue * Time.deltaTime;
        Energy -= EnergyConsumptionValue * Time.deltaTime;
        _playerStateMachine.CurrentPlayerState.Update();
    }

    private void CheckLimitLifeValues()
    {
        if (Eat <= 0)
        {
            Eat = 0;
        }

        if (Energy <= 0)
        {
            Energy = 0;
        }
    }
}
