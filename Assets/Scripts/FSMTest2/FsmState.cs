namespace Assets.Scripts.FSMTest2
{
    public abstract class FsmState
    {
        protected readonly IStateSwitcher _stateSwitcher;
        
        public FsmState(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        public virtual void Start() { }
        public virtual void Stop() { }

        public abstract void Update();
    }
}
