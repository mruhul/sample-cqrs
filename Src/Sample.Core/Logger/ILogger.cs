namespace Sample.Core.Logger
{
    public interface ILogger
    {
        void Debug(string message);
        void Debug(string message, params object[] args);
    }
}
