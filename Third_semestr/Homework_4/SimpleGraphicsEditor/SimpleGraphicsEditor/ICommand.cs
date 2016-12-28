namespace SimpleGraphicsEditor
{
    /// <summary>
    /// interface for commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// name of command
        /// </summary>
        string Name { get; }

        /// <summary>
        /// execute the command
        /// </summary>
        void Execute();

        /// <summary>
        /// revert command
        /// </summary>
        void UnExecute();
    }
}
