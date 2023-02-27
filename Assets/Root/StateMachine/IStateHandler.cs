namespace Root.PixelGame.StateMachines
{
    internal interface IStateHandler
    {
        void ChangeState(StateType stateType);
    }
}
