namespace Assets.MicroWarcraft.Utils
{
    public delegate void ExecuteHandle();

    public interface ICommand
    {
        event ExecuteHandle ExecuteHandle;
        void Execute();
    }
}
