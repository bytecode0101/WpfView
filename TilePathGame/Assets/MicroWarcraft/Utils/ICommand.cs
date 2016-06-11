namespace Assets.MicroWarcraft.Utils
{
    //
    // Summary:
    //     Defines a command.
    public interface ICommand
    {
        //TODO:
        // Summary:
        //     Defines the method to be called when the command is invoked.
        //
        // Parameters:
        //   parameter:
        //     Data used by the command. If the command does not require data to be passed,
        //     this object can be set to null.
        void Execute(object parameter);
    }
}
