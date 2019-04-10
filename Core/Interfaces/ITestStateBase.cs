namespace Core.Interfaces
{
    public interface ITestStateBase
    {
        string Name { get; }

        void HandleKeyPress(IConnectionServiceBase connectionService, char key);
    }
}
