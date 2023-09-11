using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public event Action OnEndAnim;

    [SerializeField] private Animator _animator;
    private string _currentAnimation;

    public string PlayerWalk { get; private set; } = "Walking";
    public string PlayerEat { get; private set; } = "EatFruit";
    public string PlayerSleep { get; private set; } = "Sleep";

    public void ChangeAnimation(string newState)
    {
        if (_currentAnimation == newState) return;

        _animator.Play(newState);

        _currentAnimation = newState;
    }

    private void EndAnimationTrigger() => OnEndAnim?.Invoke();
}