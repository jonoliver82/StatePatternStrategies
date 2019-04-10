namespace SequentialPattern.Interfaces
{
    public interface ISequentialStateFactory
    {
        ITestState CreateNext();
    }
}
