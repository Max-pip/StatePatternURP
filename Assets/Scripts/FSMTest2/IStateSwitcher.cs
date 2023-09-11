namespace Assets.Scripts.FSMTest2
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : FsmState;
    }
}